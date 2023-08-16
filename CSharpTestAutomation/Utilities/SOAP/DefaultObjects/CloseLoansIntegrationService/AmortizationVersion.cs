using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultAmortizationVersion
    {
        public static MortgageLoanAmortizationVersion CreateDefaultMortgageLoanAmortizationVersion()
        {
            return new MortgageLoanAmortizationVersion
            {
                GrossRate = 1.19M,
                Periodicity = PeriodicityEnum.Monthly,
                RevisionEndDate = new DateTime(2022, 1, 1),
                RevisionPeriod = RevisionPeriodEnum.One,
                RateAdaptationList = new RateAdaptation[] {DefaultRateAdaptation.CreateDefaultRateAdaptation()}
            };
        }
    }
}
