using OpenQA.Selenium;

namespace WebdriverTaskWithooutPageFactory
{
    internal class ProtonLoginPage
    {
        private readonly IWebDriver driver;
        public readonly string url = "https://account.proton.me/login";

        public ProtonLoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        IWebElement InputEmailField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@id = 'username']"));
            }
        }

        IWebElement InputPasswordField
        {
            get
            {
                return driver.FindElement(By.XPath("//input[@id = 'password']"));
            }
        }

        IWebElement SubmitButton
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@type= 'submit']"));
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void LogIn(string adress, string password)
        {
            InputEmailField.Clear();
            InputPasswordField.Clear();
            InputEmailField.SendKeys(adress);
            InputPasswordField.SendKeys(password);
            SubmitButton.Click();
        }
    }
}
