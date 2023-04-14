using FrameworkTask.Driver;
using FrameworkTask.Model;
using FrameworkTask.Pages;
using FrameworkTask.Service;

namespace FrameworkTask.Tests
{
    public class BaseTest: IDisposable
    {
        public DriverSingleton driverSingleton;
        public CloudGoogleCalculatorPage cloudGoogleCalculatorPage;
        public YopmailPage yopmailPage;
        public ComputeEngineRequestModel model;

        public BaseTest()
        {
            string configPath = Directory.GetFiles(Directory.GetCurrentDirectory() +
                Path.DirectorySeparatorChar + @"Config\", "appsettings.*.json").FirstOrDefault();
            model = ConfigReader.Read(configPath);

            driverSingleton = DriverSingleton.Create("firefox");
            driverSingleton.GetDriver.Manage().Window.Maximize();
            cloudGoogleCalculatorPage = new(driverSingleton.GetDriver);
            yopmailPage = new(driverSingleton.GetDriver);
        }

        public void Dispose()
        {
            driverSingleton.CloseDriver();
        }
    }
}
