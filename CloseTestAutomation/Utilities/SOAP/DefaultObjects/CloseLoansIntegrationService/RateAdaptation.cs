using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultRateAdaptation
    {
        public static RateAdaptation CreateDefaultRateAdaptation()
        {
            return new RateAdaptation
            {
                RateAdaptationName = 503,
                RateAdaptationPercentage = 0.10M
            };
        }
    }
}
