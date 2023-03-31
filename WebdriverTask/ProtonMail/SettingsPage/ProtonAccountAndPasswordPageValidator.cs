using OpenQA.Selenium;

namespace WebdriverTask.ProtonMail.SettingsPage
{
    internal class ProtonAccountAndPasswordPageValidator
    {
        protected readonly IWebDriver driver;

        public ProtonAccountAndPasswordPageValidator(IWebDriver driver)
        {
            this.driver = driver;
        }

        protected ProtonAccountAndPasswordPageMap Map
        {
            get
            {
                return new ProtonAccountAndPasswordPageMap(driver);
            }
        }

        public void ValidateDisplaynameChange(string expectedName)
        {
            Assert.Equal(expectedName, Map.Displayname);
        }

        public void ValidateHeaderDisplaynameChange(string expectedName)
        {
            Assert.Contains(expectedName, Map.HeaderMenuButton.GetAttribute("title"));
        }
    }
}
