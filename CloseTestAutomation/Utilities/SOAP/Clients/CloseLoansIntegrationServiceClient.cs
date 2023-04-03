using CloseTestAutomation.Utilities.SOAP.Clients;

namespace CloseLoansIntegrationServiceReference
{

    public class CloseLoansIntegrationClient
    {
        public static TResponse ExecuteOperation<TRequest, TResponse>(TRequest request, Func<CloseLoansIntegrationServiceClient, TRequest, TResponse> operation)
        {
            try
            {
                using (var client = ClientFactory.CreateCloseLoansIntegrationServiceClient())
                {
                    return operation(client, request);
                }
            }
            catch (Exception innerException)
            {
                // Handle exception or throw it
                throw new CloseLoansIntegrationException($"Failing while trying to call the operation {operation} with request {request}", innerException);
            }
        }
        // You can add other methods here

        public class CloseLoansIntegrationException : Exception
        {
            public CloseLoansIntegrationException(string message) : base(message) { }

            public CloseLoansIntegrationException(string message, Exception innerException)
        : base(message, innerException) { }

        }
    }
}