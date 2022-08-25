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
	public class JsonProductsHandler : IProductHandler
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
        }

        public IList<object> GetProducts()
        {
            return (IList<object>)_products;
        }

        public void SaveProducts()
        {
            foreach(ProductsJson pj in _products)
            {
                Console.WriteLine("Importing: "+pj);
            }
            _repo.SaveProducts(_products);
        }
    }
}

