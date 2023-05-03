using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService;

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
                CreditList = new CreditDto[] {DefaultCreditDto.CreateDefaultCreditPrecomputed()},
                ConstructionDepotList = new ConstructionDepot[] { DefaultConstructionDepot.CreateDefaultConstructionDepot()}
            };
        }
    }
}
