using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics.Tracing;

namespace WebdriverTask.ProtonMail.LoginPage
{
    internal class ProtonLoginPageMap
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public ProtonLoginPageMap(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(15));
        }

        public IWebElement InputEmailField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'username']")));
                return driver.FindElement(By.XPath("//input[@id = 'username']"));
            }
        }

        public IWebElement InputPasswordField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id = 'password']")));
                return driver.FindElement(By.XPath("//input[@id = 'password']"));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@type= 'submit'][@aria-busy = 'false']"));
            }
        }
        public IWebElement SubmitButtonBusy
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@type= 'submit'][@aria-busy = 'true']"));
            }
        }

        public IWebElement CapchaWindow
        {
            get
            {
                return driver.FindElement(By.XPath("//div[@data-testid='verification']"));
            }
        }

        public bool SolvingCapchaIsRequired
        {
            get
            {
                return driver.FindElements(By.XPath("//div[@data-testid='verification']")).Count > 0;
            }
        }

        public By Notification
        {
            get
            {
                return By.XPath("//span[@class = 'notification__content']");
            }
        }

        public By NecessaryFieldAlertName
        {
            get
            {
               return By.XPath("//div[@id = 'id-3']//span");
            }
        }

        public By NecessaryFieldAlertPassword
        {
            get
            {
                return By.XPath("//div[@id = 'id-4']//span");
            }
        }
    }
}
