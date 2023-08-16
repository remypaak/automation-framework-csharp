using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultPartyDetailRegion
    {
        public static PartyDetailRegion CreateDefaultDutchPartyDetailRegion()
        {
            return new DutchPartyDetailRegion
            {
                BirthName = "Mathieu",
                Initials = "MVDP",
                ResidenceDocumentType = 6
            };
        }
    }
}
