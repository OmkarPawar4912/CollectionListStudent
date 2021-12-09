using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionListConsole
{
    class Program
    {
        public static void Main()
        {
            Student.Add();
            Student.View();
            Student.Delete();
        } 

        public class Student 
        {
            public string Name { get; set; }
            public int RollNo { get; set; }
            public string SubName { get; set; }

            static List<Student> Division1 = new List<Student>();
            static List<Student> Division2 = new List<Student>();

            public static void Add()
            {
                
                Console.WriteLine("Enter Total Student : ");
                int total = int.Parse(Console.ReadLine());
                //Add Student
                do
                {
                    Console.WriteLine("-----------------------------------------------------------------------------");

                    Console.Write("Enter Student Roll No  : ");
                    int no = int.Parse(Console.ReadLine());

                    Console.Write("Enter Student Name     : ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Student Subject  : ");
                    string subName = Console.ReadLine();

                    Student student = new Student()
                    {
                        Name = name,
                        RollNo = no,
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
            public static void View()
            {
                Console.WriteLine("========================================== All Student ===========================================");
               
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
                    Console.WriteLine("Student Division 2 => \t Roll No : {0} \t Name  : {1} \tSubject Name : {2}", division2.RollNo, division2.Name, division2.SubName);
                }

            }
            
            public static void FindStudent(int rollno)
            {
                Division2.ForEach(item => Division1.Add(item));
               var result= Division2.Single(s => s.RollNo == rollno);
                Console.WriteLine("{0} {1} {2}",result.RollNo,result.Name,result.SubName);
                //  string result = Division1.Single(s => s == search);
            }

            public static void Delete()
            {
                Console.WriteLine("========================================== Delete Student ===========================================");
                Console.Write("Enter Roll No : ");

                int rollno = int.Parse(Console.ReadLine());
                FindStudent(rollno);
                Console.WriteLine("Do you want to delete this Student ? ( Y / N )");
                if ("Y" == Console.ReadLine().ToUpper())
                {
                    Division1.RemoveAll(x => x.RollNo == rollno);
                    Division2.RemoveAll(x => x.RollNo == rollno);
                }
                else
                {
                    Console.WriteLine("You cancel this Process !!! ");
                }
                View();
            }
        }
    }
}
