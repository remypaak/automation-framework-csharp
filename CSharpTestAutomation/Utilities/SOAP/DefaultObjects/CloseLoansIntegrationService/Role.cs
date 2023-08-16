using CloseLoansIntegrationServiceReference;


namespace CloseTestAutomation.Utilities.SOAP.DefaultObjects.CloseLoansIntegrationService
{
    public static class DefaultRole
    {
        public static Role CreateDefaultRole()
        {
            return new Role
            {
                RoleType = 1,
                Party = DefaultParty.CreateDefaultPerson()
            };
        }
    }
}
