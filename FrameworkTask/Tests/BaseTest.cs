using FrameworkTask.Driver;
using FrameworkTask.Model;
using FrameworkTask.Pages;
using FrameworkTask.Service;
using NLog;

namespace FrameworkTask.Tests
{
    public abstract class BaseTest: IDisposable
    {
        public DriverSingleton driverSingleton;
        public CloudGoogleSearchPage cloudGoogleSearchPage;
        public CloudGoogleCalculatorPage cloudGoogleCalculatorPage;
        public YopmailPage yopmailPage;
        public ComputeEngineRequestModel model;
        public static Logger logger;

        public BaseTest()
        {
            string configPath = Directory.GetFiles(Directory.GetCurrentDirectory() +
                Path.DirectorySeparatorChar + @"Config\", "appsettings.*.json").FirstOrDefault();
            model = ConfigReader.Read(configPath);

            logger = LogManager.GetCurrentClassLogger();

            driverSingleton = DriverSingleton.Create("firefox");
            driverSingleton.GetDriver.Manage().Window.Maximize();
            cloudGoogleSearchPage = new(driverSingleton.GetDriver);
            cloudGoogleCalculatorPage = new(driverSingleton.GetDriver);
            yopmailPage = new(driverSingleton.GetDriver);
        }

        public void Dispose()
        {
            driverSingleton.CloseDriver();
            LogManager.Shutdown();
        }
    }
}
