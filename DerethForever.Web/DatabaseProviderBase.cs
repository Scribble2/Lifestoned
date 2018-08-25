using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace DerethForever.Web
{
	public class DatabaseProviderBase
	{
		private static DbProviderFactory DbFactory;
		private static string ConnectionString;

		static DatabaseProviderBase()
		{
			ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings["AuthDbConnection"];
			if (cs == null)
				throw new InvalidOperationException("AuthDbConnection connection string not configured");

			ConnectionString = cs.ConnectionString;
			DbFactory = DbProviderFactories.GetFactory(cs.ProviderName);
		}

		protected DbConnection GetConnection()
		{
			DbConnection connection = DbFactory.CreateConnection();
			connection.ConnectionString = ConnectionString;
			connection.Open();
			return connection;
		}
	}
}