using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloseTestAutomation.Utilities.PageObjects.DossierLevel
{
    public class PageDepotInfo : DossierLevelBasePageObject
    {
        public override string? Title => "DEPOT INFO";
        public PageDepotInfo(WebdriverWrapper driver) : base(driver)
        {
            _driver = driver;
        }

        public string depotEndDateValue => _driver.GetElement(By.CssSelector("[name=\"ConstructionDepotEnddate\"] input")).GetAttribute("value");

        public string depotInitialAmountValue => _driver.GetElement(By.Name("DepotBalanceInitialAmount")).GetAttribute("value");

        public bool useForPrepaymentValue => Convert.ToBoolean(_driver.GetElement(By.CssSelector("[name=\"UseOutStandingForPrepaymentAllowed\"] input")).GetAttribute("aria-checked"));



    }
}
