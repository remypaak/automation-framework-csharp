using BatchIntegrationServiceReference;
using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Config;
using CloseTestAutomation.TestSuite.BaseTestFixtures;
using CloseTestAutomation.Utilities.Database;
using CloseTestAutomation.Utilities.Enums;
using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Utilities.PageObjects.DossierLevel;
using CloseTestAutomation.Utilities.PageObjects.WideLevel;
using CloseTestAutomation.Utilities.SOAP.DefaultObjects;
using CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService;
using OpenQA.Selenium;

namespace CloseTestAutomation.TestSuite.Pilot
{
    [TestFixture]
    public class PilotTests : BaseTestFixture
    {
        [Test]
        public void AutomaticPrepaymentAfterDepotEnded()
        {
            //First Block: Create Request
            string creditDossierExternalReference = Randomizer.GetRandomString();
            string creditExternalReference = creditDossierExternalReference + Randomizer.GetRandomNumberString(2);

            MortgageLoanRequest request = DefaultMortgageLoanRequest.CreateDefaultMortgageLoanRequest();
            request.CreditDossier.ExternalReference = creditDossierExternalReference;
            request.CreditDossier.CreditList[0].ExternalReference = creditExternalReference;
            request.CreditDossier.PaymentOutList[0].Amount = 595000M;

            var depot = DefaultConstructionDepot.CreateDefaultConstructionDepot();
            depot.EndDate = depot.StartDate.Value.AddMonths(2);
            depot.InterestEndDate = depot.EndDate;
            depot.ConstructionDepot2CreditList = new ConstructionDepot2CreditDto[] { new ConstructionDepot2CreditDto { ExternalCreditReference = creditExternalReference } };
            request.CreditDossier.ConstructionDepotList[0] = depot;

            LoansHelper.CreateMortgageDossier(request);

            //Second Block: Move to Depot info Screen
            UIHelper.GoToMainPage(WebDriver);

            var pageDepotInfo = new PageDepotInfo(WebDriver);
            pageDepotInfo.NavigateTo(new WideLevelBasePageObject(WebDriver), creditDossierExternalReference);

            //Third Block: Assert values in Depot info screen
            Asserts.AreDatesEqual(pageDepotInfo.depotEndDateValue, depot.EndDate);
            Asserts.AreAmountsEqual(pageDepotInfo.depotInitialAmountValue, request.CreditDossier.ConstructionDepotList[0].InitialAmount);
            Thread.Sleep(5000);
            Assert.That(pageDepotInfo.useForPrepaymentValue, Is.EqualTo(request.CreditDossier.ConstructionDepotList[0].UseOutstandingForPrepaymentAllowed));


            TimeTravel.TimeTravelToDate(depot.EndDate.Value, creditDossierExternalReference);
            //Fourth Block: Run Depot schedule and Construction depot end date batch
            RunBatchScheduleRequest batchScheduleRequest = new RunBatchScheduleRequest { BatchScheduleId = (int)BatchScheduleID.DepotSchedule };
            BatchClient.ExecuteOperation(batchScheduleRequest, (client, request) => client.RunBatchSchedule(request));
            BatchHelper.WaitForAllBatchedToBeExecuted();

            RunBatchRequest batchRequest = new RunBatchRequest { BatchName = new BatchNameDto { CodeId = CachedCodeTables.GetCodeId("batchname", "PROCESSENDOFCONSTRUCTIONDEPOT") } };
            RunBatchResponse batchResponse = BatchClient.ExecuteOperation(batchRequest, (client, request) => client.RunBatch(request));



        }
    }
}
