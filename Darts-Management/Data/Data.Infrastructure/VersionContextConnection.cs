using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Darts.Data.Infrastructure
{
    public class VersionContextConnection
    {
        public static string GetDatabaseConnectionstring()
        {
            NpgsqlConnectionStringBuilder npgsqlConnectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = "localhost",
                Port = 5432,
                Database = "darts_management",
                Username = "postgres",//GlobalVariables.DB_User,
                Password = "masterkey"//GlobalVariables.DB_Password
            };

            return npgsqlConnectionStringBuilder.ConnectionString;
        }
    }
}
