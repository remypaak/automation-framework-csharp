using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultCreditDetail
    {
        public static MortgageCreditDetail CreateDefaultMortgageCreditDetail()
        {
            return new MortgageCreditDetail
            {
                FiscalRegime = 1
            };
        }
    }
}
