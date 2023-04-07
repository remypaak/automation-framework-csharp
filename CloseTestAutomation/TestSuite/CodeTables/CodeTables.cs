using CloseLoansIntegrationServiceReference;
using CloseTestAutomation.TestSuite.BaseTestFixtures;
using CloseTestAutomation.Utilities.Helpers;

namespace CloseTestAutomation.TestSuite.CodeTables
{
    [TestFixture]
    public class CodeTables : BaseTestFixture
    {
        [Test]
        public void GetCodeTables()
        {
            Console.WriteLine(CachedCodeTables.GetTranslation("txtype", "PAYMENTALLOCATION"));
            Console.WriteLine(CachedCodeTables.GetTranslation("gender", "MALE"));
        }
    }
}
