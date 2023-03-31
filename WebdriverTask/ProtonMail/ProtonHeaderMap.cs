using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonHeaderMap
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;

        public ProtonHeaderMap(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(driver, TimeSpan.FromSeconds(15));
        }

        public IWebElement AboutUserButton
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@data-testid = 'heading:userdropdown']"));
            }
        }

        public IWebElement HeaderMenuButton
        {
            get
            {
                return driver.FindElement(By.XPath("//button[@data-testid = 'heading:userdropdown']"));
            }
        }

        public By Notification
        {
            get
            {
                return By.XPath("//span[@class='notification__content']");
            }
        }
    }
}
