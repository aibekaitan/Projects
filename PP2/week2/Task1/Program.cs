using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int cnt;
            cnt = 0;
            
            
            if(line.Length%2==0)
            for(int i=((line.Length/2) -1); i>=0; i--)
            {
                for(int j= (line.Length / 2 +cnt); j<line.Length; j++)
                {
                        if (line[i] == line[j])
                        {
                            cnt++;
                            break;
                        }
                        else 
                        {
                            break;
                        }
                }
            }
            else
                for (int i = ((line.Length / 2)-1); i >= 0; i--)
                {
                    for (int j = ((line.Length / 2) +1+cnt); j < line.Length; j++)
                    {
                        
                        if (line[i] == line[j])
                        {
                            cnt++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            
            if (((line.Length / 2) )== cnt)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
