using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebdriverTask.ProtonMail;
using WebdriverTask.GMail;

namespace WebdriverTask
{
    public class GmailProtonMailSendTests
    {
        IWebDriver driver = new ChromeDriver();
        string correctProtonEmailAddress = "WebdriverTest@proton.me";
        string correctProtonEmailPassword = "8xG79Y5Qd3S6WAR";
        string correctGmailAddress = "WebdriverTest70@gmail.com";
        string correctGmailPassword = "CEgKiVex5sx8fuy";
        string protonLoginPageUrl = "https://account.proton.me/login";
        string protonInboxUrl = "https://mail.proton.me/u/0/inbox";
        string messageSubject;
        string messageBody;

        WebDriverWait wait;
        GmailLoginPage gmailLoginPage;
        GmailInboxPage gmailInboxPage;
        ProtonLoginPage protonLoginPage;
        ProtonInboxPage protonInboxPage;

        [Fact]
        public void Proton_Login_With_Correct_Credentials_Redirect_To_Inbox()
        {
            string actualUrl;
            protonLoginPage = new(driver);
            wait = new(driver, TimeSpan.FromSeconds(10));

            protonLoginPage.Navigate();
            wait.Until(ExpectedConditions.UrlContains(protonLoginPageUrl));
            protonLoginPage.LogIn(correctProtonEmailAddress, correctProtonEmailPassword);
            wait.Until(ExpectedConditions.UrlContains(protonInboxUrl));
            actualUrl = driver.Url;

            protonLoginPage.Validator.ValidateLoginSuccess(protonInboxUrl);
        }
                
        public void Gmail_Login_With_Correct_Credentials_Redirect_To_Inbox()
        {
            string actualUrl;
            gmailLoginPage = new(driver);

            gmailLoginPage.Navigate();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            gmailLoginPage.LogIn(correctGmailAddress, correctGmailPassword);
            actualUrl = driver.Url;
        }

        [Fact]
        public void Mail_Send_From_Proton_Reaches_Designated_Gmail_Address()
        {
            protonInboxPage = new(driver);

            protonLoginPage.LogIn(correctProtonEmailAddress, correctProtonEmailPassword);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            protonInboxPage.SendMail(correctGmailAddress, "Test message subject", "Test message text2");

        }

        [Fact]
        public void CheckSentMail()
        {
            protonLoginPage = new(driver);
            protonInboxPage = new(driver);

            protonLoginPage.Navigate();
            protonLoginPage.LogIn(correctProtonEmailAddress, correctProtonEmailPassword);

            protonInboxPage.Validator.ValidateMailArrival("ardos125@gmail.com", "Saaa");
        }
    }
}