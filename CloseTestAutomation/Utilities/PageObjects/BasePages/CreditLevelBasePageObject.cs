using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;

namespace CloseTestAutomation.Utilities.PageObjects.BasePages
{
    public class CreditLevelBasePageObject : IPageObject
    {
        public WebdriverWrapper _driver { get; set; }
        public CreditLevelBasePageObject(WebdriverWrapper driver){
            _driver = driver;
        }
        public virtual string? Title { get; }

        public List<string> FinanceMenuPages = new List<string> { "FINANCIAL INFO", "CREATE MANUAL TRANSACTION", "FINANCIAL OVERVIEW ", "CHARGE PREPAYMENT FOR MORTGAGE NL",
        "MANAGE REVERSE TX", "DIRECT DEBIT", "VIEW DIRECT DEBIT INFO", "REMISSION OF DUE"};

        
        public IWebElement GetCreditReferenceNav(int creditIndex)
        {
            return _driver.GetElement(By.XPath($"((//*[@id=\"CreditDossierInfo\"])//following-sibling::div//*[@for=\"68CreditReference\"]//following-sibling::div//a)[{creditIndex}]"));
        }

        public IWebElement NavigationPage(string pageTitle)
        {
            return _driver.GetElement(By.CssSelector($"[title=\"{pageTitle}\"]"));
        }
        IWebElement financeMenu => _driver.GetElement(By.CssSelector("[title=\"FINANCE\"]"));
        public void NavigateTo(IPageObject? currentPageObject, int creditIndex)
        {
            if (currentPageObject is CreditLevelBasePageObject)
            {

            }
            else if (currentPageObject is DossierLevelBasePageObject)
            {
                SelectCredit(creditIndex);
                if (FinanceMenuPages.Contains(Title)) {
                    Console.WriteLine("Zoek Finance Menu");
                    _driver.Click(financeMenu);
                    Console.WriteLine("Finance Menu gevonden");
                }
                var navigationPage = NavigationPage(Title);
                _driver.Click(navigationPage);

            }
            else if (currentPageObject is WideLevelBasePageObject)
            {

            }
        }

        public void SelectCredit(int creditIndex)
        {
            _driver.Click(GetCreditReferenceNav(creditIndex));

        }
    }
}
