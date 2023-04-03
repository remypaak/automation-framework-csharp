using CloseTestAutomation.Config;
using CloseTestAutomation.TestSuite.BaseTestFixtures;


namespace CloseTestAutomation.TestSuite.Login
{
    [TestFixture]
    public class Login : BaseTestFixture
    {
        [Test]
        public void TestLogin()
        {
            // Create an instance of the PageLogin class
            var pageLogin = new PageLogin(WebDriver);
            // Navigate to the login page
            pageLogin.NavigateTo(null);

            // Perform the login action
            string userName = CloseConfig.GetCloseBOUserName();
            string password = CloseConfig.GetCloseBOPassword();
            pageLogin.Login(userName, password);
            pageLogin.SelectNNSchadeSession();

            // Add your assertions here to verify the login was successful
            // For example, check if you're on the expected page or if an element is visible
        }
    }
}