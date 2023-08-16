using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace CloseTestAutomation.Utilities.Webdriver
{



    public static class WebdriverFactory {
        public static WebdriverWrapper GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--ignore-certificate-errors");
            ChromeDriver driver = new ChromeDriver(options);
            return new WebdriverWrapper(driver);
        }
        public static WebdriverWrapper GetEdgeDriver()
        {
            EdgeOptions options = new EdgeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--ignore-certificate-errors");
            EdgeDriver driver = new EdgeDriver(options);
            return new WebdriverWrapper(driver);
        }
    }
}

