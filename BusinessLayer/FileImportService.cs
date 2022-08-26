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
                    IProductsHandler productsHandler = Factory.GetInstance(file.Extension);
                    if (!(productsHandler is null)) {
                        productsHandler.ImportProducts(file);
                        productsHandler.SaveProducts();
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

