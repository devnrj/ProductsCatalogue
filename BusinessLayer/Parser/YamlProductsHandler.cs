using System;
using System.Collections.Generic;
using System.IO;
using BusinessLayer.Interfaces;
using Domain.Models;
using DataLayer.Repositories;
using YamlDotNet.Serialization.NamingConventions;

namespace BusinessLayer.Parser
{
	public class YamlProductsHandler : IProductsHandler
	{
        private List<ProductsYaml> _products { get; set; }
        private IRepository<ProductsYaml> _repo { get; set; }

        public YamlProductsHandler()
		{
            _products = new List<ProductsYaml>();
            _repo = new ProductsRepository<ProductsYaml>();
        }

        public IList<object> GetProducts()
        {
            return (IList<object>)_products;
        }

        public void ImportProducts(FileInfo data)
        {
            Console.WriteLine("Yaml Product Handler - Import : Started");
            try
            {
                var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
                _products = deserializer.Deserialize<List<ProductsYaml>>(File.ReadAllText(data.FullName));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            Console.WriteLine("Yaml Product Handler - Import : Completed");
        }

        public void SaveProducts()
        {
            Console.WriteLine("Yaml Product Handler - Save : Started");
            foreach (ProductsYaml py in _products)
            {
                Console.WriteLine("Importing: " + py);
            }
            _repo.SaveProducts(_products);
            Console.WriteLine("Yaml Product Handler - Save : Completed");
        }
    }
}

