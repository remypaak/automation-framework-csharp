using CloseTestAutomation.Config;
using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.Helpers
{
    public static class UIHelper
    {
        public static void GoToMainPage(WebdriverWrapper driver)
        {
            var pageLogin = new PageLogin(driver);
            pageLogin.NavigateTo(null);

            string userName = CloseConfig.GetCloseBOUserName();
            string password = CloseConfig.GetCloseBOPassword();
            pageLogin.Login(userName, password);
            pageLogin.SelectNNSchadeSession();
        }
    }
}
