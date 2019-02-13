using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {   
        static void Main(string[] args)
        {   
            FileStream fs = new FileStream("C:/c#/Text1.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string text = sr.ReadToEnd();

            int[] numbers = F1(text);
            
            Console.WriteLine(text);
            sr.Close();
            fs.Close();
            FileStream fs2 = new FileStream(@"C:/c#/output.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            
            int[] primeNumbers = F2(numbers);

            
            foreach (var t in primeNumbers)
            {
                Console.WriteLine(t + " ");
                sw.Write(t + " ");
            }

            sw.Close();
            fs2.Close();

        }
        private static int[] F1(string text)
        {
            string[] parts = text.Split();
            int[] res = new int[parts.Length];
            for(int i = 0; i < parts.Length; i++)
            {
                res[i] = int.Parse(parts[i]);
            }
            return res;

        }
        private static int[] F2(int[] numbers)
        {
            List<int> res = new List<int>();
            int a;
            foreach (var x in numbers) 
            {
                a = 0; 
                for (int j = 1; j <= x; j++) 
                {
                    if (x % j == 0) 
                    {
                        a++;
                        if (a == 2 && x == j)
                        {
                             res.Add(x);
                        }
                    }
                }
            }
            return res.ToArray();
        }
    }
}
