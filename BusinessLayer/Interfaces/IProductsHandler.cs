using System.IO;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
	public interface IProductHandler
	{
		void ImportProducts(FileInfo data);
		IList<object> GetProducts();
		void SaveProducts();
	}
}

