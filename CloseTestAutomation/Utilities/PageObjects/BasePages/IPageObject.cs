using CloseTestAutomation.Utilities.Webdriver;
using CloseTestAutomation.Utilities.PageObjects.BasePages;

namespace CloseTestAutomation.Utilities.PageObjects.BasePages
{
    public interface IPageObject
    {
        public WebdriverWrapper _driver { get; set; }
        public static string? Title { get; }
    }
}
    
