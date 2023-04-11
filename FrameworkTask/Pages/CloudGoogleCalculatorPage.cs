using FrameworkTask.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    internal class CloudGoogleCalculatorPage
    {
        protected readonly string url = "https://cloud.google.com/products/calculator";
        IWebDriver driver;
        WebDriverWait wait;
        public CloudGoogleCalculatorPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new(this.driver, TimeSpan.FromSeconds(5));
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
            wait.Until(ExpectedConditions.ElementToBeClickable(Map.OsAndSoftwareMenu));
            Map.MenuOption(Map.OsAndSoftwareMenu, $"{request.Os}").Click();

            Map.ProvisioningModelTab.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Map.ProvisioningModelMenu));
            Map.MenuOption(Map.ProvisioningModelMenu, $"{request.ProvisioningModel}").Click();

            Map.MachineSeriesTab.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Map.MachineSeriesMenu));
            Map.MenuOption(Map.MachineSeriesMenu, $"{request.MachineSeries}").Click();

            Map.MachineTypeTab.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Map.MachineTypeMenu));
            Map.MenuOption(Map.MachineTypeMenu, $"{request.MachineType}").Click();

            if (request.HasAdditionalGpus)
            {
                Map.GpuAddCheckbox.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(Map.GpuTypeTab));
                Map.GpuTypeTab.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(Map.GpuTypeMenu));
                Map.MenuOption(Map.GpuTypeMenu, $"{request.GpuType}").Click();
                Map.GpuCountTab.Click();
                wait.Until(ExpectedConditions.ElementToBeClickable(Map.GpuCountMenu));
                Map.MenuOption(Map.GpuCountMenu, $"{request.GpuCount}").Click();
            }

            Map.LocalSsdTab.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Map.LocalSsdMenu));
            Map.MenuOption(Map.LocalSsdMenu, $"{request.LocalSsds}").Click();

            Map.DatacenterLocationTab.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Map.DatacenterLocationMenu));
            Map.MenuOption(Map.DatacenterLocationMenu, $"{request.DatecenterLocation}").Click();

            Map.CommittedUsageTab.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(Map.CommittedUsageMenu));
            Map.MenuOption(Map.CommittedUsageMenu, $"{request.CommittedUsage}").Click();

            Map.AddToEstimateButton.Click();
            driver.SwitchTo().DefaultContent();
        }

        public string GetEstimatedCost()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//article[@id='cloud-site']//iframe")));
            driver.SwitchTo().Frame(driver.FindElement(By.XPath("//article[@id='cloud-site']//iframe")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("myFrame")));
            driver.SwitchTo().Frame("myFrame");
            wait.Until(ExpectedConditions.ElementIsVisible(Map.estimatedCost));
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

            wait.Until(ExpectedConditions.ElementIsVisible(Map.buttonOpeningMailEstimateDialogue));
            Map.ButtonOpeningMailEstimateDialogue.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(Map.mailEstimateDialogueEmailField));
            Map.MailEstimateDialogueEmailField.SendKeys(address);
            Map.MailEstimateDialogueSendEmailButton.Click();
            driver.SwitchTo().DefaultContent();
        }
    }
}
