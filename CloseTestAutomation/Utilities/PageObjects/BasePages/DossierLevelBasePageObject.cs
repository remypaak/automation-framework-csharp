using CloseTestAutomation.Utilities.PageObjects.WideLevel;
using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;


namespace CloseTestAutomation.Utilities.PageObjects.BasePages
{
    public class DossierLevelBasePageObject : IPageObject
    {
        public WebdriverWrapper _driver { get; set; }
        public virtual string? Title { get; }
        public DossierLevelBasePageObject(WebdriverWrapper driver){
            _driver = driver;
        }
        public IWebElement GetPageToNavigateTo(string pageTitle)
        {
            return _driver.GetElement(By.CssSelector($"[title=\"{pageTitle}\"]"));
        }
        public void NavigateTo(IPageObject? currentPageObject, string dossierReference = "")
        {
            
            if (currentPageObject is DossierLevelBasePageObject || currentPageObject is CreditLevelBasePageObject)
            {
                var navigationPage = GetPageToNavigateTo(Title);
                _driver.Click(navigationPage);

            }
            else if (currentPageObject is WideLevelBasePageObject)
            {
                var pageDossierSearch = new PageDossierSearch(_driver);
                pageDossierSearch.SelectCreditDosser(dossierReference);
                var navigationPage = GetPageToNavigateTo(Title);
                Console.WriteLine(Title);
                Thread.Sleep(1000);
                _driver.Click(navigationPage);

            }
        }
    }
}
