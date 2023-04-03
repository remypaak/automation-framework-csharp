using BatchIntegrationServiceReference;
using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.TestSuite.BaseTestFixtures;
using CloseTestAutomation.Utilities.Enums;
using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.SOAP.Clients;
using CloseTestAutomation.Utilities.SOAP.DefaultObjects;


namespace CloseTestAutomation.TestSuite.CreateDossier
{
    [TestFixture]
    public class CreateDossier : BaseTestFixture
    {
        [Test]
        public void TestCreateMortgageDossier()
        {
            // Set non default values for the MortgageLoanRequest
            string creditExternalReference = Randomizer.GetRandomString();
            string creditDossierExternalReference = creditExternalReference.Substring(0, 10);

            // Create default MortgageLoanRequest and enrich with non default values
            MortgageLoanRequest request = DefaultMortgageLoanRequest.CreateDefaultMortgageLoanRequest();
            request.CreditDossier.ExternalReference = creditDossierExternalReference;
            request.CreditDossier.CreditList[0].ExternalReference = creditExternalReference;

            LoansHelper.CreateMortgageDossier(request);
        }
    }
}
