using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionListConsole
{
    class Program
    {
        static List<Student> Division1 = new List<Student>();
        static List<Student> Division2 = new List<Student>();

        public static void Main()
        {
            Program.Menu(); // Display Menu
        }
        public static void Chose(int n)
        { 
            switch (n)
            {
                case 1:
                    Student.Add();
                    break;
                case 2:

                    Student.View();
                    break;
                case 3:
                    Student.FindOrDelete();
                    break;
                case 4:
                    Student.Total();
                    break;
                case 5:
                    Environment.Exit(0); // For exit
                    break;
                default:
                    Console.WriteLine("Invalid Entry!");
                    break;
            }
        }
        public static void Menu()
        {
            bool exitMenuLoop = false;           
            do
            {
                Console.WriteLine("===================================================================");
                Console.WriteLine(" 1 - Add Student ");
                Console.WriteLine(" 2 - View Student ");
                Console.WriteLine(" 3 - Find or Delete Student ");
                Console.WriteLine(" 4 - Exit");
                Console.WriteLine("Enter Your option");
                
                int option = int.Parse(Console.ReadLine());
                
                if (option > 0 && option < 5)
                {
                    Program.Chose(option);
                }
                else
                {
                    Console.WriteLine("\nThe selection has to be between 1 and 4, please re-enter your selection");
                }

            } while (!exitMenuLoop);
        }      

        public class Student 
        {
            public string Name { get; set; }
            public int RollNo { get; set; }
            public string SubName { get; set; }

            //Add Student
            public static void Add()
            {

                Console.WriteLine("Enter Total Student : ");
                int total = int.Parse(Console.ReadLine());
                do
                {
                    //For Auto Genrated Roll No
                    int rn;
                    if(Total()==0)
                    {
                        rn =1;
                    }
                    else
                    {
                        rn = Total() + 1;
                    }

                    Console.WriteLine("-----------------------------------------------------------------------------");
                    
                    Console.Write("Student Roll No  : {0} \n",rn);
                  
                    Console.Write("Enter Student Name     : ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Student Subject  : ");
                    string subName = Console.ReadLine();

                    Student student = new Student()
                    {
                        Name = name,
                        RollNo = rn,
                        SubName = subName
                    };

                    if (total % 2 == 0)
                    {
                        Division1.Add(student);
                        total--;
                    }
                    else
                    {
                        Division2.Add(student);
                        total--;
                    }

                } while (total > 0);
            }

            //All Student List
            public static void View()
            {
                Console.WriteLine("========================================== All Student =====================================================");
               
                // All Student
                var result = Division1.Concat(Division2).OrderBy(x => x.RollNo).ToList();

                foreach (var allStudent in result)
                {
                    Console.WriteLine("Roll No : {0} \t Name  : {1} \tSubject Name : {2}", allStudent.RollNo, allStudent.Name, allStudent.SubName);
                }

                Console.WriteLine("========================================== Division wise ===========================================");

                //Display Division 1 List
                foreach (var division1 in Division1)
                {
                    Console.WriteLine("Student Division 1 => \t Roll No : {0} \t Name  : {1} \tSubject Name : {2}", division1.RollNo, division1.Name, division1.SubName);
                }

                Console.WriteLine();
               
                //Display Division 2 List
                foreach (var division2 in Division2)
                {
                    Console.WriteLine("Student Division 2 => \tRoll No : {0} \t Name  : {1} \tSubject Name : {2}", division2.RollNo, division2.Name, division2.SubName);
                }

            }

            //Find
            public static void FindStudent(int division, int rollno)
            {

                if (division == 1)
                {
                    var result = Division1.Single(s => s.RollNo == rollno);
                    Console.WriteLine("Division {0} => \tRoll No : {1} \t Name  : {2} \tSubject Name : {3}", division, result.RollNo, result.Name, result.SubName);
                }
                if (division == 2)
                {
                    var result = Division2.Single(s => s.RollNo == rollno);
                    Console.WriteLine("Division {0} => \tRoll No : {1} \t Name  : {2} \tSubject Name : {3}", division, result.RollNo, result.Name, result.SubName);
                }
            }

            public static int Total()
            {
                var result = Division1.Concat(Division2).OrderBy(x => x.RollNo).ToList();
                return result.Count();
            }

            //Find And Delete
            public static void FindOrDelete()
            {
                Console.WriteLine("========================================== Delete Student ===========================================");
                Console.Write("Enter Division (1 or 2): ");
                int division = int.Parse(Console.ReadLine());
                
                Console.Write("Enter Roll No : ");
                int rollno = int.Parse(Console.ReadLine());
                
                FindStudent(division, rollno);
                Console.WriteLine("Do you want to delete or edit this Student( D = delete | N = Exit) ? ");
                
                if ("D" == Console.ReadLine().ToUpper())
                {
                    Division1.RemoveAll(x => x.RollNo == rollno);
                    Division2.RemoveAll(x => x.RollNo == rollno);
                }
                else
                {
                    Console.WriteLine("You cancel Process !!! ");
                }

                View();
            }
        }
    }
}
