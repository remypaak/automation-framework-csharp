using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Helpers;

namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects
{
    public static class DefaultPayment
    {
        public static PaymentOut CreateDefaultPaymentOut()
        {
            return new PaymentOut
            {
                Amount = 595000M,
                Country = "NL",
                PayeeName = "Test",
                PaymentId = Randomizer.GetRandomString(),
                IBANAccount = IBANGenerator.GenerateIban(),
                PaymentOutType = PaymentOutTypeEnum.PaymentToEscrow
            };
        }
    }
}
