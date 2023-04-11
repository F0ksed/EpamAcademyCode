using OpenQA.Selenium;
using System.Security.Cryptography.X509Certificates;

namespace FrameworkTask.Pages
{
    internal class YopmailPageMap
    {
        IWebDriver driver;

        By acceptNecesaryCookiesButton = By.Id("necesary");
        By createRandomAddressButton = By.XPath("//*[@href='email-generator']");
        By checkMailButton = By.XPath("//*[@class = 'nw']/button[2]");
        By currentMailboxAddress = By.XPath("//*[@class='bname']");

        public YopmailPageMap(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public IWebElement AcceptNecesaryCookiesButton => driver.FindElement(acceptNecesaryCookiesButton);
        public IWebElement CreateRandomAddressButton => driver.FindElement(createRandomAddressButton);
        public By CheckMailButton => checkMailButton;
        public By CurrentMailboxAddress => currentMailboxAddress;
    }
}
