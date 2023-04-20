using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace FrameworkTask.Pages
{
    public class CloudGoogleCalculatorPageMap : CloudGoogleBasePageMap
    {
        By iframeOuter = By.XPath("//article[@id='cloud-site']//iframe");
        By iframeCalculator = By.XPath("//*[@id = 'maia-main']//iframe");
        By computeEngineTab = By.Id("tab-item-1");
        By numberOfInstancesField = By.Id("input_95");
        By osAndSoftwareTab = By.Id("select_108");
        By provisioningModelTab = By.Id("select_112");
        By machineSeriesTab = By.Id("select_120");
        By machineTypeTab = By.Id("select_122");
        By gpuAddCheckbox = By.XPath("//form[@name = 'ComputeEngineForm']//md-checkbox[@*[contains(., 'Gpu')]]");
        By gpuTypeTab = By.XPath("./ancestor::div[2]/following-sibling::div[1]/descendant::md-select[1]");
        By gpuCountTab = By.XPath("./ancestor::div[2]/following-sibling::div[1]/descendant::md-select[2]");
        By localSsdTab = By.Id("select_445");
        By datacenterLocationTab = By.Id("select_128");
        By committedUsageTab = By.Id("select_135");
        By addToEstimateButton = By.XPath("//form[@name = 'ComputeEngineForm']//button[@class[not(contains(., 'tooltip'))]]");
        By estimatedCost = By.XPath("//*[@class = 'cpc-cart-total']/h2/b");
        By buttonOpeningMailEstimateDialogue = By.Id("Email Estimate");
        By mailEstimateDialogueEmailField = By.XPath("//input[@type ='email']");
        By mailEstimateDialogueSendEmailButton = By.XPath("//form[@name = 'emailForm']/md-dialog-actions/button[2]");

        public CloudGoogleCalculatorPageMap(IWebDriver driver) : base(driver) { }

        public By IframeOuter => iframeOuter;
        public By IframeCalculator => iframeCalculator;
        public IWebElement ComputeEngineTab
        {
            get
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(computeEngineTab));
                return driver.FindElement(computeEngineTab);
            }
        }
        public IWebElement NumberOfInstancesField => driver.FindElement(numberOfInstancesField);
        public IWebElement OsAndSoftwareTab => driver.FindElement(osAndSoftwareTab);
        public IWebElement ProvisioningModelTab => driver.FindElement(provisioningModelTab);
        public IWebElement MachineSeriesTab => driver.FindElement(machineSeriesTab);
        public IWebElement MachineTypeTab => driver.FindElement(machineTypeTab);
        public IWebElement GpuAddCheckbox => driver.FindElement(gpuAddCheckbox);
        public IWebElement GpuTypeTab => GpuAddCheckbox.FindElement(gpuTypeTab);
        public IWebElement GpuCountTab => GpuAddCheckbox.FindElement(gpuCountTab);
        public IWebElement LocalSsdTab => driver.FindElement(localSsdTab);
        public IWebElement DatacenterLocationTab => driver.FindElement(datacenterLocationTab);
        public IWebElement CommittedUsageTab => driver.FindElement(committedUsageTab);
        public IWebElement AddToEstimateButton => driver.FindElement(addToEstimateButton);
        public IWebElement EstimatedCost => driver.FindElement(estimatedCost);
        public IWebElement ButtonOpeningMailEstimateDialogue => driver.FindElement(buttonOpeningMailEstimateDialogue);
        public IWebElement MailEstimateDialogueEmailField => driver.FindElement(mailEstimateDialogueEmailField);
        public IWebElement MailEstimateDialogueSendEmailButton => driver.FindElement(mailEstimateDialogueSendEmailButton);

        public IWebElement MenuOption(string option)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//text()[normalize-space() = '{option}' " +
                $"and not (ancestor::div[@aria-hidden = 'true'])]//ancestor::md-option")));
            return driver.FindElement(By.XPath($"//text()[normalize-space() = '{option}' " +
                $"and not (ancestor::div[@aria-hidden = 'true'])]//ancestor::md-option"));
        }
    }
}
