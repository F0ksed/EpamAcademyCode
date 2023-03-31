using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail.SettingsPage
{
    internal class ProtonAccountAndPasswordPage
    {
        protected readonly IWebDriver driver;
        protected readonly string url = "https://account.proton.me/u/6/mail/account-password";
        WebDriverWait wait;

        public ProtonAccountAndPasswordPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        public ProtonAccountAndPasswordPageValidator Validator
        {
            get
            {
                return new ProtonAccountAndPasswordPageValidator(driver);
            }
        }

        public ProtonAccountAndPasswordPageMap Map
        {
            get
            {
                return new ProtonAccountAndPasswordPageMap(driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ChangeDisplayname(string displayname) 
        {
            Map.EditDisplaynameButton.Click();
            Map.InputNewDisplaynameField.SendKeys(displayname);
            Map.DialogSubmitButton.Click();
            wait.Until(ExpectedConditions.StalenessOf(Map.DialogueContainer));
            wait.Until(ExpectedConditions.StalenessOf(driver.FindElement(Map.Notification)));
        }

    }
}
