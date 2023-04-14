using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    internal class YopmailPageMap
    {
        IWebDriver driver;
        WebDriverWait wait;

        By acceptNecesaryCookiesButton = By.Id("necesary");
        By createRandomAddressButton = By.XPath("//*[@href='email-generator']");
        By checkMailButton = By.XPath("//*[@class = 'nw']/button[2]");
        By currentMailboxAddress = By.XPath("//*[@class='bname']");
        By refreshButton = By.Id("refresh");

        public YopmailPageMap(IWebDriver driver) 
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(5));
        }

        public IEnumerable<IWebElement> AcceptNecesaryCookiesButton => driver.FindElements(acceptNecesaryCookiesButton);
        public IWebElement CreateRandomAddressButton => driver.FindElement(createRandomAddressButton);
        public IWebElement CheckMailButton
        {
            get
            {
                wait.Until(ExpectedConditions.ElementExists(checkMailButton));
                return driver.FindElement(checkMailButton);
            }
        }
        public IWebElement CurrentMailboxAddress
        {
            get
            {
                wait.Until(ExpectedConditions.ElementExists(currentMailboxAddress));
                return driver.FindElement(currentMailboxAddress);
            }
        }        
        public IWebElement RefreshButton => driver.FindElement(refreshButton);
    }
}
