using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.SOAP.Clients;

namespace BatchIntegrationServiceReference
{
    
    public class BatchClient
    {
        public static TResponse ExecuteOperation<TRequest, TResponse>(TRequest request, Func<BatchServiceClient, TRequest, TResponse> operation)
        {
            try
            {
                using (var client = ClientFactory.CreateBatchServiceClient())
                {
                    BatchHelper.WaitForAllBatchedToBeExecuted();
                    return operation(client, request);
                }
            }
            catch (Exception innerException)
            {
                // Handle exception or throw it
                throw new BatchException($"Failing while trying to call the operation {operation} with request {request}", innerException);
            }
        }
        public static void ExecuteOperation<TRequest>(TRequest request, Action<BatchServiceClient, TRequest> operation)
        {
            try
            {
                using (var client = ClientFactory.CreateBatchServiceClient())
                {
                    BatchHelper.WaitForAllBatchedToBeExecuted();
                    operation(client, request);
                }
            }
            catch (Exception innerException)
            {
                // Handle exception or throw it
                throw new BatchException($"Failing while trying to call the operation {operation} with request {request}", innerException);
            }
        }

        public static bool ExecuteOperation<TRequest>(TRequest request, Func<BatchServiceClient, TRequest, bool> operation)
        {
            try
            {
                using (var client = ClientFactory.CreateBatchServiceClient())
                {
                    BatchHelper.WaitForAllBatchedToBeExecuted();
                    return operation(client, request);
                }
            }
            catch (Exception innerException)
            {
                // Handle exception or throw it
                throw new BatchException($"Failing while trying to call the operation {operation} with request {request}", innerException);
            }
        }
    }
    public class BatchException : Exception
    {
        public BatchException(string message) : base(message) { }

        public BatchException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
