﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {   string[] lines = { "First line", "Second line", "Third line" };
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:/c#/Text1.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
        }
    }
}
