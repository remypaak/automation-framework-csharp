using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using CloseTestAutomation.Config;
using Dapper;
using Npgsql;

namespace CloseTestAutomation.Utilities.Database
{
    public class DBSessionFactory
    {
        public static IDbConnection CreateDBSession()
        {
            var connectionString = $"Server={CloseConfig.GetDBHost()};Port={CloseConfig.GetDBPort()};Database={CloseConfig.GetDBName()};Username={CloseConfig.GetDBUsername()};Password={CloseConfig.GetDBPassword()}";
            return new NpgsqlConnection(connectionString);
        }
    }
}
