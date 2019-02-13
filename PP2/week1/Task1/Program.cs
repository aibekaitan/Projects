using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, a, c; //appointment of a new changes of type int
            c = 0; //appointment of a new changes of type int "c" to 0, which is prime numbers, there is 0 prime numbers
            num = Convert.ToInt32(Console.ReadLine()); //Giving new changes of type int "num" to number of inputing digits using Convert.ToInt32

            string line1 = Console.ReadLine(); //Inputing string with digits and appointment of a new changes of type string which called line1

            string[] digits = line1.Split(new char[] { ' ' }); //splitting line1 using operation Split and Split spaces with " " , appointment new array of strings
            int[] set = new int[num];  //appointment new array which type is int, called set
            for (int i = 0; i < num; i++) //appointment new cycle for parsing digits(which is strings) to set(which is itegers)
            {
                set[i] = Int32.Parse(digits[i]);  //Using Int32.Parse to change string type to int
            }

            for (int i = 0; i < num; i++) //all digits from 0 to "num" which is dividend
            {
                a = 0; //this int using for checking prime numbers, if a=2 it is prime becouse prime must be divisible by 1 and himself
                for (int j = 1; j <= set[i]; j++) //is it all number from 1 to "num" which is dividers 
                {
                    if (set[i] % j == 0) //checking for is it prime or not, from 1 to set[i], if a equal to 2 it will be prime
                    {
                        a++;//counter dividint without remainders
                        if (a == 2 && set[i] == j) //if at the and of cycle a=2 and j is equal to set[i], is will be prime
                            c++; //counter prime numbers
                    }
                }
            }
            Console.WriteLine(c); //outputing prime numbers
            for (int i = 0; i < num; i++) //same process
            {
                a = 0;
                for (int j = 1; j <= set[i]; j++)
                {
                    if (set[i] % j == 0)
                    {
                        a++;
                        if (a == 2 && set[i] == j)
                            Console.Write(set[i] + " "); //just printing all prime numbers to console
                    }
                }
            }

            Console.ReadKey(); //The End 
        }
    }
}