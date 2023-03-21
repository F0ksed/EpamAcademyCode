using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.GMail
{
    internal class GmailLoginPage
    {
        private readonly IWebDriver driver;
        WebDriverWait wait;
        private readonly string url = "https://mail.google.com/";
        private readonly string passwordXPath = "//input[@* = 'password']";


        public GmailLoginPage(IWebDriver browser)
        {
            driver = browser;
            wait = new(driver, TimeSpan.FromSeconds(10));
        }

        IWebElement InputEmailField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@* = 'email']"));
            }
        }

        IWebElement InputPasswordField
        {
            get
            {
                return driver.FindElement(By.XPath(passwordXPath));
            }
        }

        IWebElement NextButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[attribute::data-primary-action-label]/div/div[1]//button"));
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LogIn(string address, string password)
        {
            InputEmailField.Clear();
            InputEmailField.SendKeys(address);
            NextButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(passwordXPath)));
            InputPasswordField.SendKeys(password);
            NextButton.Click();

        }

    }
}
