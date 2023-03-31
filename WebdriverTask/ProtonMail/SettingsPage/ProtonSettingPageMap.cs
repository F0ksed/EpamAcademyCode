using OpenQA.Selenium;

namespace WebdriverTask.ProtonMail.SettingsPage
{
    internal class ProtonSettingPageMap : ProtonHeaderMap
    {
        public ProtonSettingPageMap(IWebDriver driver) : base(driver) { }

        public IWebElement AccountAndPasswordTab
        {
            get
            {
                return driver.FindElement(By.XPath("//nav/ul/ul[1]/li[5]"));
            }
        }
    }
}
