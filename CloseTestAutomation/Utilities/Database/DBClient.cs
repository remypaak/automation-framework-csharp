using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.Database
{
    public static class DBClient
    {
        public static IEnumerable<T> Select<T>(string query)
        {
            using (var session = DBSessionFactory.CreateDBSession())
            {
                Console.WriteLine("Sessie aangemaakt");
                return session.Query<T>(query);
            }
        }
    }
}
