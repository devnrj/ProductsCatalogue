using System.IO;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
	public interface IProductsHandler
	{
		void ImportProducts(FileInfo data);
		IList<object> GetProducts();
		void SaveProducts();
	}
}

