using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager3
{
    enum ViewMode
    {
        ShowDirContent,
        ShowFileContent
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Public\KBTU");
            Stack<Layer> history = new Stack<Layer>();
            
            history.Push(
                new Layer
                {
                    Content = dir.GetFileSystemInfos()
                }
            );

            ViewMode viewMode = ViewMode.ShowDirContent;
            bool esc = false;
            while (!esc)
            {
                if (viewMode == ViewMode.ShowDirContent)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.M: // если нажали М 

                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.Clear(); // чистим консоль 

                        string name = Console.ReadLine(); // Вводим новое имя для файла или папки 

                        int x3 = history.Peek().SelectedItem; // захватываем индекс выбранного курсором файла или папки 

                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3]; // берем его по индексу 

                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo)) // проверяем файл ли он 

                        {

                            DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo; // создаем вторую такую же директорию 
                            Console.WriteLine(directoryInfo.Parent);
                            Console.WriteLine(fileSystemInfo3.FullName);
                            Directory.Move(fileSystemInfo3.FullName, directoryInfo.Parent.FullName + "/" + name); // изначальный путь файла, 
                                                       //путь на который нужно поменять , изза того что после преспоследнего слеша мы меняем 
                                                                                                       // его имя то берем его парент то есть без имени директории и присоединяем имя которое мы ввели в консоль 
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos(); // ну и конечно же изза того что мы поменяли 
                                                                                                // имя файла нужно теперь его контент изменить в истории 
                        }

                        else

                        {

                            FileInfo fileInfo = fileSystemInfo3 as FileInfo; // если это не папка а файл то превращаем файл систем инфо в файл инфо 
                            Console.WriteLine(fileSystemInfo3.FullName);
                            Console.WriteLine(fileInfo.Directory.FullName);
                            File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name); // так же прям меняем имя 
                            
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos(); // опять изменяем его в стэке 
                            Console.ReadKey();
                        }



                        break;
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        history.Peek().SelectedItem--;
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo fileInfo = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();
                        }


                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];

                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            viewMode = ViewMode.ShowDirContent;
                            DirectoryInfo selectedDir = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = selectedDir.GetFileSystemInfos() });
                        }
                        else
                        {
                            viewMode = ViewMode.ShowFileContent;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (viewMode == ViewMode.ShowDirContent)
                        {
                            history.Pop();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            viewMode = ViewMode.ShowDirContent;
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;
                        break;
                }
            }
        }
    }
}