using FrameworkTask.Model;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    public class CloudGoogleCalculatorPage: CloudGoogleBasePage
    {
        protected readonly string url = "https://cloud.google.com/products/calculator";

        public CloudGoogleCalculatorPage(IWebDriver driver): base(driver) { }

        private CloudGoogleCalculatorPageMap Map => new CloudGoogleCalculatorPageMap(driver);

        public void Navigate() => driver.Navigate().GoToUrl(url);

        public void FillRequest(ComputeEngineRequestModel request)
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(Map.IframeOuter));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(Map.IframeCalculator));

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
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(Map.IframeOuter));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(Map.IframeCalculator));
            string cost = Map.EstimatedCost.Text;
            driver.SwitchTo().DefaultContent();
            return cost;
        }

        public void MailEstimatedCost(string address)
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(Map.IframeOuter));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(Map.IframeCalculator));
            Map.ButtonOpeningMailEstimateDialogue.Click();
            Map.MailEstimateDialogueEmailField.SendKeys(address);
            Map.MailEstimateDialogueSendEmailButton.Click();
            driver.SwitchTo().DefaultContent();
        }
    }
}
