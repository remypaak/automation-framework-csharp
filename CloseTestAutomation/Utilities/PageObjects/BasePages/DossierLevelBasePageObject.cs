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
        public void NavigateTo(IPageObject? currentPageObject, int creditIndex = 0)
        {
            if (currentPageObject is DossierLevelBasePageObject || currentPageObject is CreditLevelBasePageObject)
            {

            }
            else if (currentPageObject is WideLevelBasePageObject)
            {

            }
        }
    }
}
