using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;
using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Config;
using OpenQA.Selenium.Support.UI;

public class PageLogin : IPageObject
{
    public WebdriverWrapper _driver { get; set; }
    public static string? Title;
    public PageLogin(WebdriverWrapper driver) {
     _driver = driver;
    }

    public void NavigateTo(IPageObject? currentPageObject, int creditIndex = 0)
    {
        _driver.Navigate().GoToUrl(CloseConfig.GetCloseBOURL());
    }

    IWebElement userNameTxtField => _driver.GetElement(By.Name("UserName"));
    IWebElement passwordTxtField => _driver.GetElement(By.Name("Password"));

    IWebElement submitButton => _driver.GetElement(By.Id("submitButton"));

    IWebElement sessionNNSchadeButton => _driver.GetElement(By.CssSelector("button.card-custom:nth-child(1)"));

    public void Login(string userName, string password)
    {
        _driver.SetText(userNameTxtField, userName);
        _driver.SetText(passwordTxtField, password);
        _driver.Click(submitButton);
    }

    public void SelectNNSchadeSession()
    {
        _driver.Click(sessionNNSchadeButton);
    }

}
