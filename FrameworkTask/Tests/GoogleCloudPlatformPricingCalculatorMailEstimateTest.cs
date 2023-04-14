using FrameworkTask.Driver;
using FrameworkTask.Model;
using FrameworkTask.Pages;
using FrameworkTask.Service;
using OpenQA.Selenium;
using System.Reflection;

namespace FrameworkTask.Tests
{
    public class GoogleCloudPlatformPricingCalculatorMailEstimateTest : BaseTest
    {
        [Fact]
        public void GoogleCloudPlatformPricing()
        {
            cloudGoogleCalculatorPage.Navigate();
            cloudGoogleCalculatorPage.FillRequest(model);
            string estimatedCost = cloudGoogleCalculatorPage.GetEstimatedCost();
            string googleCalculatorWindowHandle = driverSingleton.GetDriver.CurrentWindowHandle;

            driverSingleton.GetDriver.SwitchTo().NewWindow(WindowType.Tab);
            yopmailPage.Navigate();
            yopmailPage.CreateNewMailbox();
            string address = yopmailPage.GetMailAddress();
            string yopmailPageWindowHandle = driverSingleton.GetDriver.CurrentWindowHandle;

            driverSingleton.GetDriver.SwitchTo().Window(googleCalculatorWindowHandle);
            cloudGoogleCalculatorPage.MailEstimatedCost(address);
            driverSingleton.GetDriver.SwitchTo().Window(yopmailPageWindowHandle);

            yopmailPage.CheckMail("Google Cloud Price Estimate", 2);

        }
    }
}