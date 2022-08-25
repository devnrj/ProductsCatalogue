using System;
using System.IO;
using BusinessLayer;

namespace ProductsCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saas Products Import Utility");
            try
            {
                string path = Path.GetFullPath(args[0]);
                FileImportService fis = new FileImportService();
                fis.ImportFiles(path);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadKey();
        }
    }
}

