using BatchIntegrationServiceReference;
using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Enums;

namespace CloseTestAutomation.Utilities.Helpers
{
    public static class LoansHelper
    {
        public static void CreateMortgageDossier(MortgageLoanRequest request)
        {
            CreditResponse response = CloseLoansIntegrationClient.ExecuteOperation(request, (client, request) => client.CreateMortgageDossierRequest(request));
            Console.WriteLine(response.CreditResult.IsSuccessful.ToString());
            RunBatchRequest batchRequest = new RunBatchRequest { BatchName = new BatchNameDto { CodeId = CachedCodeTables.GetCodeId("batchname", "PROCESSMORTGAGEDOSSIERREQUESTPAYMENTS") } };
            RunBatchResponse batchResponse = BatchClient.ExecuteOperation(batchRequest, (client, request) => client.RunBatch(request));

            UpdateMortgageDossierRequestStatusRequest updateMortgageRequest = new UpdateMortgageDossierRequestStatusRequest
            {
                UpdateMortgageDossierRequestStatus = new UpdateMortgageDossierRequestStatus
                {
                    ExternalCreditDossierReference = request.CreditDossier.ExternalReference,
                    MortgageRequestStatus = MortgageRequestStatusEnum.ToBeActivated
                }
            };
            UpdateMortgageDossierRequestStatusResponse updateMortgageResponse = CloseLoansIntegrationClient.ExecuteOperation(updateMortgageRequest, (client, request) => client.UpdateMortgageDossierRequestStatus(request));
            RunBatchScheduleRequest batchScheduleRequest = new RunBatchScheduleRequest { BatchScheduleId = (int)BatchScheduleID.FollowupSchedule };
            BatchClient.ExecuteOperation(batchScheduleRequest, (client, request) => client.RunBatchSchedule(request));
            BatchHelper.WaitForAllBatchedToBeExecuted();

        }
    }
}
