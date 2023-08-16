using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.Utilities.Helpers;

namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultAddress
    {
        public static Address CreateDefaultAddress()
        {
            return new Address
            {
                AddressType = AddressTypeEnum.ContactAddress,
                HistoricalAddress = false,
                Country = "NL",
                HouseNumber = Randomizer.GetRandomString(2),
                Street = "Postbus",
                PostalCode = "1000AP",
                City = "Amsterdam",
                HouseNumberSuffix = Randomizer.GetRandomString(1),
                Box = Randomizer.GetRandomString(5)
            };
        }
    }
}
