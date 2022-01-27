using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.App_Code
{
    public class Config
    {
        private const string connectionStringName = "AIConnectionString";
        private static string connectionString = String.Empty;
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    if (ConfigurationManager.ConnectionStrings[connectionStringName] != null)
                    {
                        connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
                    }
                    else
                    {
                        throw new Exception(String.Format("The connection string '{0}' is not defined in the configuration file", connectionStringName));
                    }
                }
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
        }
    }
}