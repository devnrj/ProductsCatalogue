using System;
using System.Collections.Generic;
using System.IO;
using BusinessLayer.Interfaces;

namespace BusinessLayer
{
    public class FileImportService
    {
        public void ImportFiles(string path)
        {
            try
            {
                DirectoryInfo rootDir = new DirectoryInfo(path);
                FileInfo[] files = null ;
                if (rootDir.Exists)
                {
                    files = rootDir.GetFiles();
                }
             

                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file.Name);
                    IProductHandler productHandler = Factory.GetInstance(file.Extension);
                    if (!(productHandler is null)) {
                        productHandler.ImportProducts(file);
                        productHandler.SaveProducts();
                    }
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }    
}

