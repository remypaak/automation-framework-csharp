using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;


namespace CloseTestAutomation.Utilities.PageObjects
{
    public class DatePicker
    {
        public WebdriverWrapper _driver { get; set; }
        public DatePicker(WebdriverWrapper driver)
        {
            _driver = driver;
        }
        public void SetDate(IWebElement element, DateTime date)
        {
            _driver.Click(element);
            SetYear(date.Year);
            SetMonth(date.Month);
            SetDay(date.Day);
        }

        private void SetYear(int year)
        {
            Console.WriteLine(year.ToString());
            _driver.Click(_driver.GetElement(By.CssSelector(".p-datepicker-year")));
            while (year < int.Parse(GetDecade().Substring(0, 4)))
            {
                _driver.Click(_driver.GetElement(By.CssSelector(".p-datepicker-prev-icon")));
            }
            while (year > int.Parse(GetDecade().Substring(5, 4)))
            {
                _driver.Click(_driver.GetElement(By.CssSelector(".p-datepicker-next")));
            }
            Console.WriteLine("Gehaald totdat ik de GetElements aan roep met index");
            _driver.Click(_driver.GetElements(By.ClassName("p-yearpicker-year"))[year % 10]);
        }

        private void SetMonth(int month)
        {
            _driver.Click(_driver.GetElements(By.ClassName("p-monthpicker-month"))[month - 1]);
        }

        private void SetDay(int day)
        {
            int deltaFromSaturday = (DateFirstSaturday() % 7 == 0) ? 7 : DateFirstSaturday() % 7;
            _driver.Click(_driver.GetElements(By.CssSelector(".p-datepicker-calendar .p-element"))[day + (7 - deltaFromSaturday - 1)]);
        }

        private string GetDecade()
        {
            return _driver.GetAttribute(By.ClassName("p-datepicker-decade"), "value");
        }

        private int DateFirstSaturday()
        {
            return int.Parse(_driver.GetAttribute(_driver.GetElements(By.CssSelector(".p-datepicker-calendar .p-element"))[6], "value"));
        }
    }
}
