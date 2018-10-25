using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace Lifestoned.Providers
{
    public class DatabaseProviderBase
    {
        protected static DbProviderFactory DbFactory { get; private set; }

        protected static string ConnectionString { get; private set; }

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