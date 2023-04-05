using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebdriverTask.ProtonMail.LoginPage;

namespace WebdriverTask
{
    public class ProtonLoginTestsChrome
    {
        [Fact]
        public void Correct_Credentials_With_Email_Address_Redirects_To_Inbox_Page()
        {
            IWebDriver driver = new ChromeDriver();
            ProtonLoginPage protonLoginPage = new(driver);
            string correctProtonEmailAddress = "WebdriverTest@proton.me";
            string correctProtonEmailPassword = "8xG79Y5Qd3S6WAR";
            string inboxUrl = "https://mail.proton.me/u/0/inbox";

            try
            {
                driver.Manage().Window.Maximize();
                protonLoginPage.Navigate();
                protonLoginPage.LogIn(correctProtonEmailAddress, correctProtonEmailPassword);
                protonLoginPage.Validator.ValidateLoginSuccess(inboxUrl);
            }
            finally
            {
                driver.Quit();
            }
        }

        [Fact]
        public void Correct_Credentials_With_Username_Redirects_To_Inbox_Page()
        {
            IWebDriver driver = new ChromeDriver();
            ProtonLoginPage protonLoginPage = new(driver);
            string correctProtonEmailAddress = "WebdriverTest";
            string correctProtonEmailPassword = "8xG79Y5Qd3S6WAR";
            string inboxUrl = "https://mail.proton.me/u/0/inbox";

            try
            {
                driver.Manage().Window.Maximize();
                protonLoginPage.Navigate();
                protonLoginPage.LogIn(correctProtonEmailAddress, correctProtonEmailPassword);
                protonLoginPage.Validator.ValidateLoginSuccess(inboxUrl);
            }
            finally
            {
                driver.Quit();
            }
        }

        [Fact]
        public void Correct_Address_Wrong_Password_Remains_On_Login_Page()
        {
            IWebDriver driver = new ChromeDriver();
            ProtonLoginPage protonLoginPage = new(driver);
            string correctProtonEmailAddress = "WebdriverTest@proton.me";
            string wrongProtonEmailPassword = "a123";
            string loginPageUrl = "https://account.proton.me/login";

            try
            {
                driver.Manage().Window.Maximize();
                protonLoginPage.Navigate();
                protonLoginPage.LogIn(correctProtonEmailAddress, wrongProtonEmailPassword);
                protonLoginPage.Validator.ValidateDeniedLogin(loginPageUrl);
            }
            finally
            {
                driver.Quit();
            }
        }

       [Fact]
        public void Wrong_Address_Correct_Password_Remains_On_Login_Page()
        {
            IWebDriver driver = new ChromeDriver();
            ProtonLoginPage protonLoginPage = new(driver);
            string wrongProtonEmailAddress = "a123@proton.me";
            string correctProtonEmailPassword = "8xG79Y5Qd3S6WAR";
            string loginPageUrl = "https://account.proton.me/login";

            try
            {
                driver.Manage().Window.Maximize();
                protonLoginPage.Navigate();
                protonLoginPage.LogIn(wrongProtonEmailAddress, correctProtonEmailPassword);
                protonLoginPage.Validator.ValidateDeniedLogin(loginPageUrl);
            }
            finally
            {
                driver.Quit();
            }
        }

        [Fact]
        public void Correct_Address_Empty_Password_Remains_On_Login_Page()
        {
            IWebDriver driver = new ChromeDriver();
            ProtonLoginPage protonLoginPage = new(driver);
            string correctProtonEmailAddress = "WebdriverTest@proton.me";
            string emptyProtonEmailPassword = string.Empty;
            string loginPageUrl = "https://account.proton.me/login";

            try
            {
                driver.Manage().Window.Maximize();
                protonLoginPage.Navigate();
                protonLoginPage.LogIn(correctProtonEmailAddress, emptyProtonEmailPassword);
                protonLoginPage.Validator.ValidateEmptyPasswordFieldLoginFailure(loginPageUrl);
            }
            finally
            {
                driver.Quit();
            }
        }

        [Fact]
        public void Empty_Address_Empty_Password_Remains_On_Login_Page()
        {
            IWebDriver driver = new ChromeDriver();
            ProtonLoginPage protonLoginPage = new(driver);
            string emptyProtonEmailAddress = string.Empty;
            string emptyProtonEmailPassword = string.Empty;
            string loginPageUrl = "https://account.proton.me/login";

            try
            {
                driver.Manage().Window.Maximize();
                protonLoginPage.Navigate();
                protonLoginPage.LogIn(emptyProtonEmailAddress, emptyProtonEmailPassword);
                protonLoginPage.Validator.ValidateEmptyNameFieldLoginFailure(loginPageUrl);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
