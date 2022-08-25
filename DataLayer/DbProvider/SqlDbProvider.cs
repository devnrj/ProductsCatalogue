using System;
namespace DataLayer.DbProvider
{
	public class SqlDbProvider : IDbProvider
    {
		public SqlDbProvider()
		{
		}

        public string GetConnectionString()
        {
            throw new NotImplementedException();
        }
    }
}

