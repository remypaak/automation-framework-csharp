using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Helpers;

namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects
{
    public static class DefaultCreditDossierDto
    {
        public static CreditDossierDto CreateDefaultCreditDossier()
        {
            return new CreditDossierDto
            {
                ExternalReference = Randomizer.GetRandomString(),
                TotalFinanceAmount = 600000M,
                DeedDate = new DateTime(2015, 12, 31),
                PaymentOutList = new Payment[] { DefaultPayment.CreateDefaultPaymentOut() },
                CreditList = new CreditDto[] {DefaultCreditDto.CreateDefaultCreditPrecomputed()}
                // Set other default values as needed
            };
        }
    }
}
