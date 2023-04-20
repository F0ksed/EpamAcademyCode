using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    public class YopmailPage
    {
        IWebDriver driver;
        WebDriverWait wait;
        private string url = "https://yopmail.com";

        public YopmailPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(5));
        }

        private YopmailPageMap Map
        {
            get
            {
                return new YopmailPageMap(this.driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
            if (Map.AcceptNecesaryCookiesButton.Count() >0)
            {
                Map.AcceptNecesaryCookiesButton.FirstOrDefault().Click();
            }
        }

        public void CreateNewMailbox()
        {
            Map.CreateRandomAddressButton.Click();            
            if (Map.AcceptNecesaryCookiesButton.Count() > 0)
            {
                Map.AcceptNecesaryCookiesButton.FirstOrDefault().Click();
            }

            Map.CheckMailButton.Click();
        }

        public string GetMailAddress() => Map.CurrentMailboxAddress.Text;        

        //hack
        public void CheckMail(string subject, int tries = 2)
        {
            int i = 0;
            while (true)
            {
                Map.RefreshButton.Click();
                try
                {
                    driver.SwitchTo().Frame("ifinbox");
                    wait.Until(ExpectedConditions.ElementExists(By.XPath($"//*[text()[contains(., '{subject}')]]")));
                    break;
                }
                catch (WebDriverTimeoutException e)
                {
                    i++;
                    if (i>=tries) 
                    {
                        throw;
                    }
                }
                finally
                {
                    driver.SwitchTo().DefaultContent();
                }
            }
        }

        public string GetEstimatedCost()
        {
            driver.SwitchTo().Frame(Map.IfrmaeMail);
            string content = Map.MailContentEstimatedCost.Text;
            driver.SwitchTo().DefaultContent();
            return content;
        }
    }
}
