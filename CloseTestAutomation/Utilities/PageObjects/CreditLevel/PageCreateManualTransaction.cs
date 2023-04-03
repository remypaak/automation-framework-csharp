using CloseTestAutomation.Utilities.PageObjects.BasePages;
using CloseTestAutomation.Utilities.Webdriver;
using OpenQA.Selenium;


namespace CloseTestAutomation.Utilities.PageObjects.CreditLevel
{


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



        public void CreateManualTransaction(TransactionType transactionType, double amount)
        {
            _driver.Click(createButton);
            _driver.SetDropdownItem(transactionTypeDropdown, transactionType);
            _driver.SetText(amountField, amount.ToString());
        }

    }
}
