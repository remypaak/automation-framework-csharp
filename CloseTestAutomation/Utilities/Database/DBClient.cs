using Dapper;
using DapperExtensions;

namespace CloseTestAutomation.Utilities.Database
{
    public static class DBClient
    {
        public static IEnumerable<T> Select<T>(string query)
        {
            using (var session = DBSessionFactory.CreateDBSession())
            {
                return session.Query<T>(query);
            }
        }

        public static void Update(string query)
        {
            using (var session = DBSessionFactory.CreateDBSession())
            {
                session.Execute(query);
            }
        }
        public static void Update<T>(T databaseObject, string tableName, string? whereSql) where T : class
        {
            // Define the SQL update statement
            string updateStatement = $"UPDATE {tableName} SET ";

            // Get the object's properties using reflection
            var properties = databaseObject.GetType().GetProperties();

            // Add each property and value to the update statement
            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                var propertyName = property.Name;
                var propertyValue = property.GetValue(databaseObject);

                // Skip properties with null
                if (propertyValue == null)
                {
                    continue;
                }

                // Add the property and value to the update statement
                updateStatement += $"{propertyName.ToLower()} = '{propertyValue}'";

                if (i < properties.Length - 1)
                {
                    updateStatement += ", ";
                }
            }

            if (whereSql != null)
            {
                updateStatement += $"{whereSql}";
            }

            // Execute the update statement using Dapper
            using (var session = DBSessionFactory.CreateDBSession())
            {
                session.Execute(updateStatement);
            }
        }
    }
}
