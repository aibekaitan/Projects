using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example8
{
    class Student
    {
        string name;
        string id;
        string year;
        public Student(string n, string i, string y)
        {
            name = n;
            id = i;
            year = y;
        }
        public void PrintInfo()
        {
            Console.WriteLine(name + " " + id + " " + year);
        }
    }

    class Master : Student
    {
        string thesis;
        public Master(string n, string g,string y, string t) : base(n, g, y)
        {
            thesis = t;
        }
        public void PrintInfo2()
        {
            base.PrintInfo();
            Console.WriteLine(thesis);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Aitan Aibek", "18BD110156","2018-2019");
            s.PrintInfo();

            Master ms = new Master("Sultanov Sabit", "18BD110111","2019-2020", "C#");
            ms.PrintInfo2();

        }
    }
}
