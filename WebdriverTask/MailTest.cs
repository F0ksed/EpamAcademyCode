using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebdriverTask;

namespace WebdriverTaskWithooutPageFactory
{
    public class MailTest
    {
        IWebDriver driver = new ChromeDriver();
        string correctProtonEmailAdress = "WebdriverTest@proton.me";
        string correctProtonEmailPassword = "8xG79Y5Qd3S6WAR";
        string correctGmailAdress = "ardos125@gmail.com";
        string correctGmailPassword = "";

        ProtonLoginPage protonLoginPage;
        ProtonInboxPage protonInboxPage;

        [Fact]
        public void Proton_Login_With_Correct_Credentials_Redirect_To_Inbox()
        {
            try
            {
                string actualUrl;

                protonLoginPage = new(driver);
                protonLoginPage.Navigate();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                protonLoginPage.LogIn(correctProtonEmailAdress, correctProtonEmailPassword);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                actualUrl = driver.Url;

                Assert.Equal(protonInboxPage.url, actualUrl);
            }
            finally { driver.Quit(); }
        }

        [Fact]
        public void Mail_Send_From_Proton_Reaches_Designated_Gmail_Address()
        {
            try
            {
                protonLoginPage = new(driver);
                protonInboxPage = new(driver);

                protonLoginPage.Navigate();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                protonLoginPage.LogIn(correctProtonEmailAdress, correctProtonEmailPassword);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                protonInboxPage.SendMail(correctGmailAdress, "Test message subject", "Test message text");
            }
            finally { driver.Quit(); }
        }

        [Fact]
        public void CheckSentMail()
        {
            protonLoginPage = new(driver);
            protonInboxPage = new(driver);
            int letterCount;

            try
            {
                protonLoginPage.Navigate();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                protonLoginPage.LogIn(correctProtonEmailAdress, correctProtonEmailPassword);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                letterCount = protonInboxPage.SearchForMail(correctGmailAdress, "Saaa", "Baaa", false).Count();

                Assert.Equal(1, letterCount);
            }
            finally { driver.Quit(); }
        }
    }
}