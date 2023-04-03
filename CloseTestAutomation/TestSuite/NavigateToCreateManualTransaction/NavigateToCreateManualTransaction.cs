using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Config;
using CloseTestAutomation.TestSuite.BaseTestFixtures;
using CloseTestAutomation.Utilities.Database.CreditBalances;
using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Utilities.PageObjects.CreditLevel;
using CloseTestAutomation.Utilities.PageObjects.WideLevel;
using CloseTestAutomation.Utilities.SOAP.DefaultObjects;


namespace CloseTestAutomation.TestSuite.NavigateToCreateManualTransaction
{
    [TestFixture]
    public class TestNavigateToCreateManualTransaction : BaseTestFixture
    {
        [Test]
        public void NavigateToCreateManualTransaction()
        {
            CreditBalancesDB creditBalances = CreditBalancesDBQuery.GetCreditBalancesByCreditReference("DepotSched01");
            Console.WriteLine(creditBalances.Bonus);
            /*
            string creditDossierExternalReference = Randomizer.GetRandomString();
            string creditExternalReference = creditDossierExternalReference + Randomizer.GetRandomNumberString(2);
            

            // Create default MortgageLoanRequest and enrich with non default values
            MortgageLoanRequest request = DefaultMortgageLoanRequest.CreateDefaultMortgageLoanRequest();
            request.CreditDossier.ExternalReference = creditDossierExternalReference;
            request.CreditDossier.CreditList[0].ExternalReference = creditExternalReference;

            LoansHelper.CreateMortgageDossier(request);

            var pageLogin = new PageLogin(WebDriver);
            pageLogin.NavigateTo(null);

            string userName = CloseConfig.GetCloseBOUserName();
            string password = CloseConfig.GetCloseBOPassword();
            pageLogin.Login(userName, password);
            pageLogin.SelectNNSchadeSession();

            var pageDossierSearch = new PageDossierSearch(WebDriver);
            pageDossierSearch.SelectCreditDosser(request.CreditDossier.ExternalReference);

            var pageCreateManualTransaction = new PageCreateManualTransaction(WebDriver);
            pageCreateManualTransaction.NavigateTo(new DossierLevelBasePageObject(WebDriver), 1);
            pageCreateManualTransaction.CreateManualTransaction(TransactionType.PaymentAllocation, 500.00);
            Thread.Sleep(10000);
            */


        }

    }
}
