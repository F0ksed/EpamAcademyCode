using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Security.Cryptography.X509Certificates;

namespace FrameworkTask.Pages
{
    internal class CloudGoogleCalculatorPageMap : CloudGoogleBasePageMap
    {
        By computeEngineTab = By.XPath("//div[@class='tab-holder compute']");
        By numberOfInstancesField = By.Id("input_95");
        By osAndSoftwareTab = By.Id("select_108");
        By osAndSoftwareDropdownMenu = By.Id("select_container_109");
        By provisioningModelTab = By.Id("select_112");
        By provisioningModelDropdownMenu = By.Id("select_container_113");
        By machineSeriesTab = By.Id("select_120");
        By machineSeriesDropdownMenu = By.Id("select_container_121");
        By machineTypeTab = By.Id("select_122");
        By machineTypeDropdownMenu = By.Id("select_container_123");
        By gpuAddCheckbox = By.XPath("//form[@name = 'ComputeEngineForm']//md-checkbox[@*[contains(., 'Gpu')]]");
        By gpuTypeTab = By.Id("select_475");
        By gpuTypeDropdownMenu = By.Id("select_container_476");
        By gpuCountTab = By.Id("select_477");
        By gpuCountDropdownMenu = By.Id("select_container_478");
        By localSsdTab = By.Id("select_434");
        By localSsdDropdownMenu = By.Id("select_container_435");
        By datacenterLocationTab = By.Id("select_128");
        By datacenterLocationDropdownMenu = By.Id("select_container_129");
        By committedUsageTab = By.Id("select_135");
        By committedUsageDropdownMenu = By.Id("select_container_136");
        By addToEstimateButton = By.XPath("//form[@name = 'ComputeEngineForm']//button[@class[not(contains(., 'tooltip'))]]");
        public By estimatedCost = By.XPath("//*[@class = 'cpc-cart-total']/h2/b");
        public By buttonOpeningMailEstimateDialogue = By.Id("Email Estimate");
        public By mailEstimateDialogueEmailField = By.Id("input_552");
        By mailEstimateDialogueSendEmailButton = By.XPath("//form[@name = 'emailForm']/md-dialog-actions/button[2]");

        public CloudGoogleCalculatorPageMap(IWebDriver driver) : base(driver) { }

        public IWebElement ComputeEngineTab => driver.FindElement(computeEngineTab);
        public IWebElement NumberOfInstancesField => driver.FindElement(numberOfInstancesField);
        public IWebElement OsAndSoftwareTab => driver.FindElement(osAndSoftwareTab);
        public IWebElement OsAndSoftwareMenu => driver.FindElement(osAndSoftwareDropdownMenu);
        public IWebElement ProvisioningModelTab => driver.FindElement(provisioningModelTab);
        public IWebElement ProvisioningModelMenu => driver.FindElement(provisioningModelDropdownMenu);
        public IWebElement MachineSeriesTab => driver.FindElement(machineSeriesTab);
        public IWebElement MachineSeriesMenu => driver.FindElement(machineSeriesDropdownMenu);
        public IWebElement MachineTypeTab => driver.FindElement(machineTypeTab);
        public IWebElement MachineTypeMenu => driver.FindElement(machineTypeDropdownMenu);
        public IWebElement GpuAddCheckbox => driver.FindElement(gpuAddCheckbox);
        public IWebElement GpuTypeTab => driver.FindElement(gpuTypeTab);
        public IWebElement GpuTypeMenu => driver.FindElement(gpuTypeDropdownMenu);
        public IWebElement GpuCountTab => driver.FindElement(gpuCountTab);
        public IWebElement GpuCountMenu => driver.FindElement(gpuCountDropdownMenu);
        public IWebElement LocalSsdTab => driver.FindElement(localSsdTab);
        public IWebElement LocalSsdMenu => driver.FindElement(localSsdDropdownMenu);
        public IWebElement DatacenterLocationTab => driver.FindElement(datacenterLocationTab);
        public IWebElement DatacenterLocationMenu => driver.FindElement(datacenterLocationDropdownMenu);
        public IWebElement CommittedUsageTab => driver.FindElement(committedUsageTab);
        public IWebElement CommittedUsageMenu => driver.FindElement(committedUsageDropdownMenu);
        public IWebElement AddToEstimateButton => driver.FindElement(addToEstimateButton);
        public IWebElement EstimatedCost => driver.FindElement(estimatedCost);
        public IWebElement ButtonOpeningMailEstimateDialogue => driver.FindElement(buttonOpeningMailEstimateDialogue);
        public IWebElement MailEstimateDialogueEmailField => driver.FindElement(mailEstimateDialogueEmailField);
        public IWebElement MailEstimateDialogueSendEmailButton => driver.FindElement(mailEstimateDialogueSendEmailButton);

        public IWebElement MenuOption(IWebElement menu, string option)
        {
            return menu.FindElement(By.XPath($".//*[contains(text(), '{option}')]"));
        }
    }
}
