using FrameworkTask.Driver;
using FrameworkTask.Model;
using FrameworkTask.Pages;
using FrameworkTask.Service;
using NLog;

namespace FrameworkTask.Tests
{
    public abstract class BaseTest: IDisposable
    {
        internal DriverSingleton driverSingleton;
        internal CloudGoogleSearchPage cloudGoogleSearchPage;
        internal CloudGoogleCalculatorPage cloudGoogleCalculatorPage;
        internal YopmailPage yopmailPage;
        internal ComputeEngineRequestModel model;
        internal static Logger logger;

        public BaseTest()
        {
            string configPath = Directory.GetFiles(Directory.GetCurrentDirectory() +
                Path.DirectorySeparatorChar + @"Config\", "appsettings.*.json").FirstOrDefault();
            model = ConfigReader.Read(configPath);

            logger = LogManager.GetCurrentClassLogger();
            driverSingleton = DriverSingleton.Create(Environment.GetEnvironmentVariable("Browser"));
            driverSingleton.GetDriver.Manage().Window.Maximize();
            cloudGoogleSearchPage = new(driverSingleton.GetDriver);
            cloudGoogleCalculatorPage = new(driverSingleton.GetDriver);
            yopmailPage = new(driverSingleton.GetDriver);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            driverSingleton.CloseDriver();
            LogManager.Shutdown();
        }
    }
}
