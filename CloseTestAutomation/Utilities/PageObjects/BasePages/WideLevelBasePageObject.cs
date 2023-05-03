using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;


namespace CloseTestAutomation.Utilities.PageObjects.BasePages
{
    public class WideLevelBasePageObject : IPageObject
    {
        public WebdriverWrapper _driver { get; set; }

        public virtual string? Title { get; }
        public WideLevelBasePageObject(WebdriverWrapper driver){
            _driver = driver;
        }
        public void NavigateTo(IPageObject? currentPageObject, string dossierReference = "", string creditReference = "")
        {
            
        }
    }
}