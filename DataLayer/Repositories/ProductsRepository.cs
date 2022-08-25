using System;
using System.Collections.Generic;
using DataLayer.Repositories;
using Domain.Models;

namespace DataLayer.Repositories
{
    public class ProductsRepository<T> : IRepository<T> where T : class
    {
        public void CreateProduct(T product)
        {
            throw new NotImplementedException();
        }


        public T GetProduct(string name)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void SaveProducts(IList<T> products)
        {
            Console.WriteLine("Saved...");
        }
    }
}

