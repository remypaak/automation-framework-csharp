using CloseTestAutomation.Utilities.Helpers;
using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;


namespace CloseTestAutomation.Utilities.PageObjects.CreditLevel
{

    [System.ComponentModel.Description("txtype")]
    public enum TransactionType
    {
        [System.ComponentModel.Description("PAYMENTALLOCATION")]
        PaymentAllocation
    }

    public class PageCreateManualTransaction : CreditLevelBasePageObject
    {
        public override string? Title => "CREATE MANUAL TRANSACTION";

        public PageCreateManualTransaction(WebdriverWrapper driver) : base(driver)
        {
            _driver = driver;
        }
        IWebElement createButton => _driver.GetElement(By.Name("Create"));

        IWebElement transactionTypeDropdown => _driver.GetElement(By.Name("TransactionTypeColon"));

        IWebElement amountField => _driver.GetElement(By.Name("AmountColon"));

        IWebElement valueDateDatePicker => _driver.GetElement(By.CssSelector("[name=\"ValueDateColon\"] .pi-calendar"));

        IWebElement saveButton => _driver.GetElement(By.CssSelector("[type=\"submit\" ]"));



        public void CreateManualTransaction(TransactionType transactionType, double amount, DateTime valueDate)
        {
            _driver.Click(createButton);
            _driver.SelectDropdownItem(transactionTypeDropdown, transactionType);
            _driver.SetText(amountField, amount.ToString());
            _driver.SetDate(valueDateDatePicker, valueDate);
            _driver.Click(saveButton);
        }

    }
}
