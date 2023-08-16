using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService;

namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects
{
    public static class DefaultCreditDto
    {
        public static CreditPrecomputed CreateDefaultCreditPrecomputed()
        {
            return new CreditPrecomputed
            {
                ExternalReference = Randomizer.GetRandomString(14),
                LoanPurpose = 1,
                PaymentReference = "MDR30351",
                RepaymentMethod = RepaymentMethodEnum.DirectDebit,
                RetailLendingSubType = RetailLendingSubTypeEnum.MortgageCredit,
                CreditProvider = 11,
                ExternalProductReference = "1011",
                AmortizationRecalculationType = AmortizationRecalculationTypeEnum.FixedDuration,
                AmortizationSchedule = AmortizationScheduleEnum.StandardPrecomputed,
                Duration = 360,
                FinanceAmount = 600000M,
                NetRate = 1.29M,
                PrepaymentPenaltyMethod = 6,
                Roles = new Role[] { DefaultRole.CreateDefaultRole() },
                CreditDetail = DefaultCreditDetail.CreateDefaultMortgageCreditDetail(),
                DirectDebit = DefaultDirectDebit.CreateDefaultDirectDebit(),
                AmortizationVersion = DefaultAmortizationVersion.CreateDefaultMortgageLoanAmortizationVersion()
            };
        }
    }
}