using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects
{
    public static class DefaultMortgageLoanRequest
    {
        public static MortgageLoanRequest CreateDefaultMortgageLoanRequest()
        {
            return new MortgageLoanRequest
            {
                LegislationCountry = "NL",
                CreditDossier = DefaultCreditDossierDto.CreateDefaultCreditDossier(),
                // Set other default properties for MortgageLoanRequest
            };
        }
    }
}
