

namespace CloseTestAutomation.Config
{
    public class CloseConfig
    {
        public static string GetBrowser()
        {
            return GetEnvironmentVariableOrDie("BROWSER");
        }
        public static string GetCloseBOURL() {
            return GetEnvironmentVariableOrDie("URL_CLOSE_BO");
        }

        public static string GetCloseBOUserName()
        {
            return GetEnvironmentVariableOrDie("TEST_USERNAME");
        }

        public static string GetCloseBOPassword()
        {
            return GetEnvironmentVariableOrDie("TEST_PASSWORD");
        }

        public static string GetCloseLoansIntegrationServiceEndPoint()
        {
            return GetEnvironmentVariableOrDie("API_URL_BO");
        }

        public static string GetBatchIntegrationServiceEndPoint()
        {
            return GetEnvironmentVariableOrDie("BATCH_SERVICE_API_URL");
        }

        public static string GetCloseBOSOAPUserName()
        {
            return GetEnvironmentVariableOrDie("SOAP_USER_NAME");
        }

        public static string GetCloseBOSOAPPassword()
        {
            return GetEnvironmentVariableOrDie("SOAP_USER_PASSWORD");
        }

        public static string GetDBDriverName()
        {
            return GetEnvironmentVariableOrDie("DB_DRIVER_NAME");
        }

        public static string GetDBHost()
        {
            return GetEnvironmentVariableOrDie("DB_HOST");
        }

        public static string GetDBPort()
        {
            return GetEnvironmentVariableOrDie("DB_PORT");
        }

        public static string GetDBUsername()
        {
            return GetEnvironmentVariableOrDie("DB_USERNAME");
        }

        public static string GetDBPassword()
        {
            return GetEnvironmentVariableOrDie("DB_PASSWORD");
        }

        public static string GetDBName() 
        {
            return GetEnvironmentVariableOrDie("DB_NAME");
        }

        public static string GetEnvironmentVariableOrDie(string envVarName)
        {
            string? envVarValue = Environment.GetEnvironmentVariable(envVarName);
            if (envVarValue == null)
            {
                throw new ArgumentException($"Environment variable does not exist: [{envVarName}]");
            }
            return envVarValue;
        }
    }
}
