using BatchIntegrationServiceReference;

namespace CloseTestAutomation.Utilities.Helpers
{
    
    public class BatchHelper
    {
        public static void WaitForAllBatchedToBeExecuted()
        {
            RequestBase request = new RequestBase();
            Retry.RetryUntilConditionIsMet(() => BatchClient.ExecuteOperation(request, (client, request) => client.IsAnyBatchBeingExecuted(request))
            , TimeSpan.FromSeconds(5), 20).Until(r => !r);
        }
    }
}
