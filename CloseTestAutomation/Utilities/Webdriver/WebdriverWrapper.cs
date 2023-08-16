using OpenQA.Selenium;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using CloseTestAutomation.Utilities.Enums;
using CloseTestAutomation.Utilities.PageObjects;
using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.Database;

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

        public IWebElement GetDropdownItem<TEnum>(Enum value) where TEnum : Enum
        {
            var table_name = EnumExtensions.GetEnumTypeDescription<TEnum>();
            var enumCaption = EnumExtensions.GetEnumDescription(value);
            return GetElement(By.CssSelector($"[aria-label=\"{CachedCodeTables.GetTranslationName(table_name, enumCaption)}\"]"));
        }
        public void Click(IWebElement element)
        {
            try
            {
                _wait.Until(e => element.Displayed && element.Enabled);

                Retry.RetryUntilConditionIsMet(() =>
                {
                    try
                    {
                        element.Click();
                        return true;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return false;
                    }
                    catch (ElementClickInterceptedException)
                    {
                        return false;
                    }
                }, TimeSpan.FromSeconds(10), 5).Until(success => success);
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to find clickable element {element}", innerException);
            }
        }

        public void SetText(IWebElement element, string value)
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

        public void SelectDropdownItem<TEnum>(IWebElement element, TEnum value) where TEnum : Enum
        {
            try
            {
                _wait.Until(e => element.Displayed && element.Enabled);
                element.Click();
                IWebElement drop_down_element = GetDropdownItem<TEnum>(value);
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
                return _wait.Until(d => d.FindElement(selector));
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to get element with selector {selector}", innerException);
            }
        }
        public IList<IWebElement> GetElements(By selector)
        {
            try
            {
                _wait.Until(d => d.FindElement(selector));
                return _driver.FindElements(selector).ToList();
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to get elements with selector {selector}", innerException);
            }
        }

        public string GetText(By selector)
        {
            try
            {
                var element = _wait.Until(d => d.FindElement(selector));
                return element.Text;
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to get text of element with selector {selector}", innerException);
            }
        }
        public string GetText(IWebElement element)
        {
            try
            {
                return element.Text;
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to get text of element {element}", innerException);
            }

        }
        public string GetAttribute(By selector, string attribute)
        {
            try
            {
                IWebElement element = GetElement(selector);
                return element.GetAttribute(attribute);
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to get the attribute {attribute} with selector {selector}", innerException);
            }
        }

        public string GetAttribute(IWebElement element, string attribute)
        {
            try
            {
                return element.GetAttribute(attribute);
            }
            catch (Exception innerException)
            {
                throw new Exception($"Failed to get the attribute {attribute} of element {element}", innerException);
            }
        }

        public void SetDate(IWebElement element, DateTime date)
        {
            DatePicker datepicker = new DatePicker(this);
            datepicker.SetDate(element, date);
        }

        public void SetDate(IWebElement element, string date)
        {
            SetText(element, date);
        }
    }
}