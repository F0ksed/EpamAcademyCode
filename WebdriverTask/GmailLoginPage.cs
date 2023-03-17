using OpenQA.Selenium;

namespace WebdriverTaskWithooutPageFactory
{
    internal class GmailLoginPage
    {
        private readonly IWebDriver driver;
        readonly string url = "https://accounts.google.com/";

        public GmailLoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        IWebElement InputEmailField 
        { 
            get
            {
                return driver.FindElement(By.XPath("//*[@* = 'email']"));
            }
        }

        IWebElement CreateAccountButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[attribute::data-primary-action-label]/div/div[2]//button"));
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

        public void InputLogin(string input) 
        {
            InputEmailField.Clear();
            InputEmailField.SendKeys(input);
            NextButton.Click();
        }
 
    }
}
