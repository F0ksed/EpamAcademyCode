using FrameworkTask.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    public class CloudGoogleCalculatorPage
    {
        protected readonly string url = "https://cloud.google.com/products/calculator";
        IWebDriver driver;
        WebDriverWait wait;
        public CloudGoogleCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(10));
        }

        private CloudGoogleCalculatorPageMap Map
        {
            get
            {
                return new CloudGoogleCalculatorPageMap(driver);
            }
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void FillRequest(ComputeEngineRequestModel request)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//article[@id='cloud-site']//iframe")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//article[@id='cloud-site']//iframe")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("myFrame")));
            driver.SwitchTo().Frame("myFrame");

            Map.ComputeEngineTab.Click();
            Map.NumberOfInstancesField.SendKeys(request.NumberOfInstances);

            Map.OsAndSoftwareTab.Click();
            Map.MenuOption($"{request.Os}").Click();

            Map.ProvisioningModelTab.Click();
            Map.MenuOption($"{request.ProvisioningModel}").Click();

            Map.MachineSeriesTab.Click();
            Map.MenuOption($"{request.MachineSeries}").Click();

            Map.MachineTypeTab.Click();
            Map.MenuOption($"{request.MachineType}").Click();

            if (request.HasAdditionalGpus)
            {
                Map.GpuAddCheckbox.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(Map.GpuTypeTab));
                Map.GpuTypeTab.Click();

                Map.MenuOption($"{request.GpuType}").Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(Map.GpuCountTab));
                Map.GpuCountTab.Click();

                Map.MenuOption($"{request.GpuCount}").Click();
            }

            Map.LocalSsdTab.Click();
            Map.MenuOption($"{request.LocalSsds}").Click();

            Map.DatacenterLocationTab.Click();
            Map.MenuOption($"{request.DatecenterLocation}").Click();

            Map.CommittedUsageTab.Click();
            Map.MenuOption($"{request.CommittedUsage}").Click();

            Map.AddToEstimateButton.Click();
            driver.SwitchTo().DefaultContent();
        }

        public string GetEstimatedCost()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//article[@id='cloud-site']//iframe")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//article[@id='cloud-site']//iframe")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("myFrame")));
            driver.SwitchTo().Frame("myFrame");

            string cost = Map.EstimatedCost.Text;
            driver.SwitchTo().DefaultContent();
            return cost;
        }

        public void MailEstimatedCost(string address)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//article[@id='cloud-site']//iframe")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//article[@id='cloud-site']//iframe")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("myFrame")));
            driver.SwitchTo().Frame("myFrame");


            Map.ButtonOpeningMailEstimateDialogue.Click();

            Map.MailEstimateDialogueEmailField.SendKeys(address);
            Map.MailEstimateDialogueSendEmailButton.Click();
            driver.SwitchTo().DefaultContent();
        }
    }
}
