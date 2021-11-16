using System;
using System.IO;
namespace Relrusion___FolderSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\chri17g5\Pictures");
            FileInfo[] files = directory.GetFiles("*");

            WriteFiles(files.Length, files);
        }

        static void WriteFiles(int count, FileInfo[] file)
        {
            try
            {
                if (count >= 1)
                    WriteFiles(count - 1, file);

                Console.WriteLine(file[count].Name);
            }
            catch 
            {
                
            }
        }
    }
}