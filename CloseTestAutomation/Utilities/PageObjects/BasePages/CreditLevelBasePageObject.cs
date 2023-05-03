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

        
        public IWebElement GetCreditReferenceNav(string creditReference)
        {
            var elements = _driver.GetElements(By.XPath($"(//*[@id=\"CreditDossierInfo\"])//following-sibling::div//*[@for=\"68CreditReference\"]//following-sibling::div//a/span"));
            foreach (var element in elements)
            {
                if (_driver.GetText(element) == creditReference){
                    return element;
                }
            }
            throw new Exception($"credit reference {creditReference} is not visible in Credit Dossier Overview");
            
        }

        public IWebElement GetPageToNavigateTo(string pageTitle)
        {
            return _driver.GetElement(By.CssSelector($"[title=\"{pageTitle}\"]"));
        }
        IWebElement financeMenu => _driver.GetElement(By.CssSelector("[title=\"FINANCE\"]"));
        public void NavigateTo(IPageObject? currentPageObject, string dossierReference = "", string creditReference = "")
        {
            
            if (currentPageObject is CreditLevelBasePageObject)
            {

            }
            else if (currentPageObject is DossierLevelBasePageObject)
            {
                SelectCredit(creditReference);
                if (FinanceMenuPages.Contains(Title)) {
                    _driver.Click(financeMenu);
                }
                var navigationPage = GetPageToNavigateTo(Title);
                _driver.Click(navigationPage);

            }
            else if (currentPageObject is WideLevelBasePageObject)
            {

            }
        }

        public void SelectCredit(string creditReference)
        {
            _driver.Click(GetCreditReferenceNav(creditReference));

        }
    }
}
