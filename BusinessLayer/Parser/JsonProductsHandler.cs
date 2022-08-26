using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using BusinessLayer.Interfaces;
using Domain.Models;
using Newtonsoft.Json.Linq;
using DataLayer.Repositories;

namespace BusinessLayer.Parser
{
	public class JsonProductsHandler : IProductsHandler
	{
		private List<ProductsJson> _products { get; set; }
        private IRepository<ProductsJson> _repo { get; set; }

        public JsonProductsHandler()
		{
			_products = new List<ProductsJson>();
            _repo = new ProductsRepository<ProductsJson>();
		}

        public void ImportProducts(FileInfo data)
        {
            Console.WriteLine("JSON Product Handler - Import : Started");
            try
            {
                JObject o1 = JObject.Parse(File.ReadAllText(data.FullName));
                JArray jArray = (JArray)o1["products"];
                _products = jArray.Select(product => new ProductsJson
                {
                    Title = (string)product["title"],
                    Categories = product["categories"].Select(category => (string)category).ToList<string>(),
                    Twitter = (string)product["twitter"]
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Console.WriteLine("JSON Product Handler - Import: Completed");
        }

        public IList<object> GetProducts()
        {
            return (IList<object>)_products;
        }

        public void SaveProducts()
        {
            Console.WriteLine("JSON Product Handler - Save : Started");
            foreach (ProductsJson pj in _products)
            {
                Console.WriteLine("Importing: "+pj);
            }
            _repo.SaveProducts(_products);
            Console.WriteLine("JSON Product Handler - Save : Completed");
        }
    }
}

