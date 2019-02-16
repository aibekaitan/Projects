using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task1UnderstandingCod
{
    // The following using directive requires a project reference to Microsoft.VisualBasic.
    using Microsoft.VisualBasic.FileIO;

    class SimpleFileCopy
    {
        static void Main()
        {
            string fileName = "test.txt";
            string sourcePath = @"c:/Users/Public/TestFolder";
            string targetPath = @"c:/Users/Public/TestFolder/SubDir";
            
            string sourceFile = Path.Combine(sourcePath, fileName);
            Console.WriteLine(sourceFile);
            string destFile = Path.Combine(targetPath, fileName);
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            File.Copy(sourceFile, destFile, true);
            if (Directory.Exists(sourcePath))
            {
                string[] files = Directory.GetFiles(sourcePath);
                foreach(string s in files)
                {
                    fileName = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, fileName);
                    File.Copy(s, destFile, true);
                }
                
            }
            
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }
    }
}
