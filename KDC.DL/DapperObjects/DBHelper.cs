using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace KDC.DL
{
    public static class DBHelper
    {
        public static string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ams_kdcdb"].ToString();
        public static IDbConnection _db = new SqlConnection(connStr);

        public static SqlConnection GetDbConnection()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ams_kdcdb"].ToString();
            var connection = new SqlConnection(connectionString.ToString());
            connection.Open();
            return connection;
        }

    }
}

