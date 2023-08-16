using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Helpers;

namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultParty
    {
        public static Person CreateDefaultPerson()
        {
            return new Person
            {
                BirthDate = new DateTime(1974, 1, 1),
                LastName = "Van der Poel",
                FirstName = Randomizer.GetRandomString(),
                PartyType = PartyTypeEnum.Person,
                PersonDetail = DefaultPartyDetail.CreateDefaultPersonDetail(),
                ExternalReference = Randomizer.GetRandomString()
            };
        }
    }
}
