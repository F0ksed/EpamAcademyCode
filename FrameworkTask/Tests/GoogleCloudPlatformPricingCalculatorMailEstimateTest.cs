using FrameworkTask.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.Network;
using System.Runtime.InteropServices;
using Xunit.Abstractions;

namespace FrameworkTask.Tests
{
    public class GoogleCloudPlatformPricingCalculatorMailEstimateTest : BaseTest
    {
        [Fact, Trait("Category", "Smoke")]
        public void MailedEstimatedCostIsEqualToCalculated()
        {
            string request = "Google Cloud Pricing Calculator";

            try
            {
                cloudGoogleSearchPage.Navigate();
                logger.Info($"Starting search on {request} request");
                cloudGoogleSearchPage.Search(request);
                cloudGoogleSearchPage.ClickSearchResultItem(request);

                logger.Info($"Filling request with {model.ToString}");
                cloudGoogleCalculatorPage.FillRequest(model);
                string estimatedCostCalculator = cloudGoogleCalculatorPage.GetEstimatedCost();
                logger.Info($"Estimation complete, output: {estimatedCostCalculator}");
                string googleCalculatorWindowHandle = driverSingleton.GetDriver.CurrentWindowHandle;

                driverSingleton.GetDriver.SwitchTo().NewWindow(WindowType.Tab);
                yopmailPage.Navigate();
                logger.Info($"Switched to yopmail window.");
                yopmailPage.CreateNewMailbox();
                string address = yopmailPage.GetMailAddress();
                logger.Info($"Created yopmail, address: {address}");
                string yopmailPageWindowHandle = driverSingleton.GetDriver.CurrentWindowHandle;

                driverSingleton.GetDriver.SwitchTo().Window(googleCalculatorWindowHandle);
                cloudGoogleCalculatorPage.MailEstimatedCost(address);
                logger.Info($"Estimated cost sent.");
                driverSingleton.GetDriver.SwitchTo().Window(yopmailPageWindowHandle);

                yopmailPage.CheckMail("Google Cloud Price Estimate", 2);

                string estimatedCostMail = yopmailPage.GetEstimatedCost();
                logger.Info($"Mail received, content: {estimatedCostMail}");
                estimatedCostMail = Util.LineCleaner.RemoveLetters(estimatedCostMail);

                Assert.Contains(estimatedCostMail, estimatedCostCalculator);
            }
            catch (Exception ex) 
            {
                logger.Error(ex);
                try
                {
                    driverSingleton.GetDriver.SwitchTo().DefaultContent();
                    driverSingleton.TakeScreenshot();
                }
                catch(Exception scr)
                {
                    logger.Error(scr, "Failed to take a screenshot");
                    throw;
                }
                throw;
            }
        }

        [Fact, Trait("Category", "Debug")]
        public void CalculatorDebug()
        {
            string request = "Google Cloud Pricing Calculator";

            cloudGoogleSearchPage.Navigate();

            cloudGoogleSearchPage.Search(request);
            cloudGoogleSearchPage.ClickSearchResultItem(request);

            cloudGoogleCalculatorPage.FillRequest(model);
            string estimatedCostCalculator = cloudGoogleCalculatorPage.GetEstimatedCost();            
        }
    }
}