using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CloseTestAutomation.Utilities.PageObjects.WideLevel
{
    public class PageDossierSearch : WideLevelBasePageObject
    {
        public static string Title = "Search Credit";
        public PageDossierSearch(WebdriverWrapper driver) : base(driver)
        {
            _driver = driver;
        }

        IWebElement creditDossierNumberField => _driver.GetElement(By.Name("DossierNumber"));

        IWebElement searchCreditButton => _driver.GetElement(By.Name("SearchCredit"));

        public IWebElement GetCreditDossierResultNav(int rowIndex = 0)
        {
            return _driver.GetElement(By.XPath($"(//*[@name='CreditSearchResult'])//tr[{rowIndex + 1}]//td[2]//a"));
        }

        public void SelectCreditDosser(string dossierExternalReference)
        {
            _driver.SetText(creditDossierNumberField, dossierExternalReference, 30);
            _driver.Click(searchCreditButton);
            _driver.Click(GetCreditDossierResultNav());

        }
    }

}
