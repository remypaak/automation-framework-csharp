using CloseTestAutomation.Config;
using CloseTestAutomation.Utilities.Webdriver;


namespace CloseTestAutomation.TestSuite.BaseTestFixtures
{
    [TestFixture]
    public abstract class BaseTestFixture
    {
        protected WebdriverWrapper WebDriver { get; private set; }

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            // Set up any one-time environment configuration here
        }

        [SetUp]
        public virtual void SetUp()
        {
            var browser = CloseConfig.GetBrowser();
            if (browser.Equals("Chrome"))
            {
                WebDriver = WebdriverFactory.GetChromeDriver();
            }
            else if (browser.Equals("Edge"))
            {
                WebDriver = WebdriverFactory.GetEdgeDriver();
            }
            else
            {
                throw new ArgumentException($"Invalid browser choice: {browser}");
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
            WebDriver.Quit();
        }
    }
}