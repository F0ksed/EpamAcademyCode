using OpenQA.Selenium;

namespace WebdriverTask.ProtonMail
{
    internal class ProtonSettingPage
    {
        private readonly IWebDriver driver;
        public readonly string url = "https://account.proton.me/u/1/mail/dashboard";

        public ProtonSettingPage(IWebDriver browser)
        {
            driver = browser;
        }


    }
}
