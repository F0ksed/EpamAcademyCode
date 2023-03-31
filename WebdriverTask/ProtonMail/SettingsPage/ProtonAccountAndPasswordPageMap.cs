using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace WebdriverTask.ProtonMail.SettingsPage
{
    internal class ProtonAccountAndPasswordPageMap : ProtonSettingPageMap
    {
        public ProtonAccountAndPasswordPageMap(IWebDriver driver) : base(driver) { }

        public string Displayname
        {
            get
            {
                return driver.FindElement(By.XPath("//section[@id = 'account']" +
                    "//div[@*[contains(., 'settings-layout-right')]]" +
                    "//button/preceding-sibling::*[contains(., text())]")).Text;
            }
        }

        public IWebElement EditDisplaynameButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//section[@id = 'account']" +
                    "//div[@*[contains(., 'settings-layout-right')]]" +
                    "//button[preceding-sibling::*[contains(., text())]]")));

                return driver.FindElement(By.XPath("//section[@id = 'account']" +
                    "//div[@*[contains(., 'settings-layout-right')]]" +
                    "//button[preceding-sibling::*[contains(., text())]]"));
            }
        }

        public IWebElement DialogueContainer
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@class[contains(., 'dialog-container')]]"));
            }
        }

        public IWebElement InputNewDisplaynameField
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id = 'displayName']")));
                return driver.FindElement(By.XPath("//input[@id = 'displayName']"));
            }
        }

        public IWebElement DialogSubmitButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@type = 'submit']")));
                return driver.FindElement(By.XPath("//button[@type = 'submit']"));
            }
        }

    }
}
