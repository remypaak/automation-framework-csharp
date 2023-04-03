using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultPartyDetail
    {
        public static PersonDetail CreateDefaultPersonDetail()
        {
            return new PersonDetail
            {
                Language = LanguageEnum.Dutch,
                Nationality = "NL",
                Gender = GenderEnum.Male,
                Addresses = new Address[] { DefaultAddress.CreateDefaultAddress() },
                PartyDetailRegion = DefaultPartyDetailRegion.CreateDefaultDutchPartyDetailRegion() 
            };
        }
    }
}
