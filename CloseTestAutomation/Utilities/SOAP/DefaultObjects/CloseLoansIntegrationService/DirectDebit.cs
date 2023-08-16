using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Helpers;

namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultDirectDebit
    {
        public static DirectDebit CreateDefaultDirectDebit()
        {
            return new DirectDebit
            {
                DirectDebitNr = Randomizer.GetRandomString(7),
                Name = Randomizer.GetRandomString(),
                IBANAccount = IBANGenerator.GenerateIban()
            };
        }
    }
}
