using System;
using BusinessLayer.Interfaces;
using BusinessLayer.Parser;

namespace BusinessLayer
{
	public static class Factory
	{
		public static IProductHandler GetInstance(string extensionName)
		{
			IProductHandler handler;
			switch (extensionName)
			{
				case ".yaml": handler = new YamlProductsHandler();
					break;
				case ".json": handler = new JsonProductsHandler();
					break;
                default:
					handler = null;
					break;
			}
			return handler;
		}
	}
}

