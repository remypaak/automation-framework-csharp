using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using CloseTestAutomation.Utilities.Enums;
namespace CloseTestAutomation.Utilities.Webdriver
{
    public class WebdriverWrapper : IWebDriver
    {
        private readonly IWebDriver _driver;
        public WebDriverWait _wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

        public WebdriverWrapper(IWebDriver driver)
        {
            _driver = driver;
        }

        public string Url { get => _driver.Url; set => _driver.Url = value; }
        public string Title => _driver.Title;
        public string PageSource => _driver.PageSource;
        public string CurrentWindowHandle => _driver.CurrentWindowHandle;
        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public void Dispose() => _driver.Dispose();
        public void Close() => _driver.Close();
        public void Quit() => _driver.Quit();

        public IWebElement FindElement(By by) => _driver.FindElement(by);
        public ReadOnlyCollection<IWebElement> FindElements(By by) => _driver.FindElements(by);

        public IOptions Manage() => _driver.Manage();
        public INavigation Navigate() => _driver.Navigate();
        public ITargetLocator SwitchTo() => _driver.SwitchTo();

        public IWebElement GetDropdownItem(Enum value)
        {
            Console.WriteLine(EnumExtensions.GetEnumDescription(value));
            return GetElement(By.CssSelector($"[aria-label=\"{EnumExtensions.GetEnumDescription(value)}\"]"));
        }
        public void Click(IWebElement element)
        {
            try
            {
                _wait.Until(e => element.Displayed && element.Enabled);
                element.Click();
            }
            catch (Exception innerException){
                throw new Exception($"Failed to find clickable element {element}", innerException);

            }
        }

        public void SetText(IWebElement element, string value, int waitTime = 5)
        {
            try
            {

                _wait.Until(e => element.Displayed && element.Enabled);
                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to find element {element} to send text to", innerException);
            }
        }

        public void SetDropdownItem(IWebElement element, Enum value, int waitTime = 5)
        {
            try
            {
                _wait.Until(e => element.Displayed && element.Enabled);
                element.Click();
                IWebElement drop_down_element = GetDropdownItem(value);
                _wait.Until(e => drop_down_element.Displayed && drop_down_element.Enabled);
                drop_down_element.Click();

            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed set dropdown item {value} in {element}", innerException);
            }
        }


        public IWebElement GetElement(By selector)
        {
            try
            {
                return _wait.Until(e => e.FindElement(selector));
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to get element with selector {selector}", innerException);
            }
        }
    }
}