using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Program
    {
        static void Main(string[] args)
        {
            int num,c;
            c = 0;
            num = Convert.ToInt32(Console.ReadLine());
            string[,] array2D = new string[num,num];
            for(int i=0; i<num; i++)
            {
                for(int j=0; j<=c; j++)
                {
                    Console.Write("[*]" + " ");
                }
                Console.WriteLine();
                c++;
            }
            Console.ReadKey();
        }
    }
}
