using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine(); //appointment new string which will be number of set
            string line2 = Console.ReadLine(); //appointment new string which all numbers which we will copy twice

            //string[] parts = line2.Split(',');
            string[] parts = line2.Split(new char[] { ' ', ',', '$' }); //Using Split to split sting in small pieces
            Console.WriteLine(parts.Length); //Using Lenght operator, to find size and print it
            int[] num = new int[parts.Length * 2];
            for (int i = 0; i < parts.Length; ++i)
            {
                num[2 * i] = num[2 * i + 1] = int.Parse(parts[i]);
                Console.Write(num[2 * i] + " " + num[2 * i + 1] + " ");
            }
            Console.ReadKey();
        }
    }
}
