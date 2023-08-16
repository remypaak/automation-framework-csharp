using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CloseTestAutomation.Config;
using CloseTestAutomation.Utilities.Webdriver;
using NUnit.Framework.Interfaces;
using System.Reflection;
using DapperExtensions;
using Microsoft.Extensions.Primitives;

namespace CloseTestAutomation.TestSuite.BaseTestFixtures
{
    [TestFixture]
    public abstract class BaseTestFixture
    {
        protected WebdriverWrapper WebDriver { get; private set; }
        protected ExtentReports Reporter { get; private set; }
        protected ExtentTest Test { get; private set; }


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { Assembly.GetExecutingAssembly() });

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