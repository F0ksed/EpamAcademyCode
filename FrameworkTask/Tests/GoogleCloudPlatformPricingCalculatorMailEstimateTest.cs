using FrameworkTask.Driver;
using FrameworkTask.Model;
using FrameworkTask.Pages;
using OpenQA.Selenium;

namespace FrameworkTask.Tests
{
    public class GoogleCloudPlatformPricingCalculatorMailEstimateTest : IDisposable
    {
        DriverSingleton driverSingleton;
        CloudGoogleCalculatorPage cloudGoogleCalculatorPage;
        YopmailPage yopmailPage;
        ComputeEngineRequestModel model;

        public GoogleCloudPlatformPricingCalculatorMailEstimateTest()
        {
            driverSingleton = DriverSingleton.Create("");
            cloudGoogleCalculatorPage = new(driverSingleton.GetDriver);
            yopmailPage = new(driverSingleton.GetDriver);
            model = new();
        }

        [Fact]
        public void Test1()
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
        }

        public void Dispose()
        {
            driverSingleton.CloseDriver();
        }
    }
}