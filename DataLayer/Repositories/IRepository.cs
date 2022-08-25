using System;
using System.Collections.Generic;
using Domain.Models;

namespace DataLayer.Repositories
{
    public interface IRepository<T> where T : class
    {
		IList<T> GetProducts();
        T GetProduct(string name);
        void CreateProduct(T product);
        void SaveProducts(IList<T> products);
     }
}

