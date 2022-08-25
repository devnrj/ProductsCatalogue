using System;
namespace DataLayer.DbProvider
{
	public class MongoDbProvider : IDbProvider
    {
		public MongoDbProvider()
		{
		}

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }
    }
}

