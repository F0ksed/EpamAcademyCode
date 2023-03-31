using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebdriverTask.GMail.LoginPage;
using WebdriverTask.GMail.InboxPage;
using WebdriverTask.Gmail.InboxPage;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebdriverTask.ProtonMail.LoginPage;
using WebdriverTask.ProtonMail.InboxPage;
using WebdriverTask.ProtonMail.SettingsPage;
using WebdriverTask.ProtonMail;

namespace WebdriverTask
{
    public class GmailProtonMailSendTests
    {
        [Fact]
        public void Proton_Gmais_Exchange_Mail_And_Proton_Changes_Displayname()
        {
            IWebDriver driver = new ChromeDriver();
            ChromeOptions chromeOptions = new();
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(10));

            string protonEmailAddress = "WebdriverTest@proton.me";
            string protonEmailPassword = "8xG79Y5Qd3S6WAR";
            string gmailAddress = "WebdriverTest70@gmail.com";
            string gmailPassword = "CEgKiVex5sx8fuy";
            string protonInboxUrl = "https://mail.proton.me/u/0/inbox";
            string protonSettingsUrl = "https://account.proton.me/u/6/mail/account-password";
            string gmailInboxUrl = "https://mail.google.com/mail/u/0/#inbox";
            string protonMessageSubject = Faker.Lorem.Sentence(3);
            string protonMessageBody = Faker.Lorem.Paragraph();
            string gmailMessageBody = Faker.Name.First() + " " + Faker.Name.Last();
            string protonWindowHandle;

            ProtonLoginPage protonLoginPage = new(driver);
            ProtonInboxPage protonInboxPage = new(driver);
            ProtonAccountAndPasswordPage protonAccountAndPasswordPage = new(driver);
            GmailLoginPage gmailLoginPage = new(driver);
            GmailMailListPage gmailMailListPage = new(driver);
            GmailOpenedLetterPage gmailOpenedLetterPage = new(driver);

            chromeOptions.AddArgument("--lang=la");
            chromeOptions.AddArguments("--start-maximized");

            try
            {
                protonLoginPage.Navigate();
                protonLoginPage.LogIn(protonEmailAddress, protonEmailPassword);
                protonLoginPage.Validator.ValidateLoginSuccess(protonInboxUrl);
                protonInboxPage.SendMail(gmailAddress, protonMessageSubject, protonMessageBody);
                protonWindowHandle = driver.CurrentWindowHandle;

                driver.SwitchTo().NewWindow(WindowType.Tab);
                gmailLoginPage.Navigate();
                gmailLoginPage.LogIn(gmailAddress, gmailPassword);
                gmailLoginPage.Validator.ValidateLoginSuccess(gmailInboxUrl);

                gmailMailListPage.Validator.ValidateMailArrival(protonEmailAddress, protonMessageSubject);
                gmailMailListPage.SelectMail(protonEmailAddress, protonMessageSubject);
                gmailMailListPage.OpenSelectedMail();
                gmailOpenedLetterPage.Validator.ValidateMailContent(protonMessageBody);
                gmailOpenedLetterPage.Reply(gmailMessageBody);

                driver.SwitchTo().Window(protonWindowHandle);
                protonInboxPage.Validator.ValidateMailArrival(gmailAddress, protonMessageSubject);
                protonInboxPage.SelectMail(gmailAddress, protonMessageSubject);
                protonInboxPage.OpenSelectedMail();
                protonInboxPage.Validator.ValidateMailContent(gmailMessageBody);

                protonAccountAndPasswordPage.Navigate();
                protonAccountAndPasswordPage.ChangeDisplayname(gmailMessageBody);
                protonAccountAndPasswordPage.Validator.ValidateDisplaynameChange(gmailMessageBody);
                protonAccountAndPasswordPage.Validator.ValidateHeaderDisplaynameChange(gmailMessageBody);
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}