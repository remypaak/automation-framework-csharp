using CloseTestAutomation.Utilities.SOAP.Clients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                    var response = operation(client, request);
                    CheckIfErrorMessage(response);
                    return response;
                }
            }
            catch (Exception ex)
            {
                string requestJson = JsonConvert.SerializeObject(request, Formatting.Indented);
                throw new CloseLoansIntegrationException($"Failing while trying to call the operation {typeof(TRequest).Name} and request : {requestJson}", ex);
            }
        }

        public static void CheckIfErrorMessage<TResponse>(TResponse response)
        {
            string responseJson = JsonConvert.SerializeObject(response, Formatting.Indented);
            JObject responseJObject = JObject.Parse(responseJson);
            JToken firstChild = responseJObject.First?.First;
            if (firstChild is JObject firstChildObject && firstChildObject.TryGetValue("ErrorMessage", out JToken errorMessage) && !string.IsNullOrEmpty(errorMessage?.ToString()))
            {
                throw new CloseLoansIntegrationException("The response contains an error message: " + responseJson);
            }
        }

        public class CloseLoansIntegrationException : Exception
        {
            public CloseLoansIntegrationException(string message) : base(message) { }

            public CloseLoansIntegrationException(string message, Exception innerException)
        : base(message, innerException) { }

        }
    }
}