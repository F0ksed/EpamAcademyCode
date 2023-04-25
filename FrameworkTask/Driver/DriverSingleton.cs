using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace FrameworkTask.Driver
{
    public class DriverSingleton
    {
        private static DriverSingleton instance;
        private static IWebDriver driver;

        private DriverSingleton() {  }

        public static DriverSingleton Create(string type)
        {
            if (instance == null) 
            {
                instance = new DriverSingleton();
                switch (type.ToLower())
                {
                    case "firefox":
                        {
                            FirefoxOptions options = new();
                            driver = new FirefoxDriver(options);
                            break;
                        }
                    default:
                        {
                            ChromeOptions options = new();
                            options.AddArgument("--whitelisted-ips='http://localhost:8080'");
                            driver = new ChromeDriver(options);
                            break;
                        }
                }           
            }

            return instance;
        }

        public IWebDriver GetDriver
        {
            get
            {
                return driver;
            }
        }        

        public void CloseDriver() 
        {
            driver.Quit();
            instance = null;
        }

        public void TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(Directory.GetCurrentDirectory() +
                Path.DirectorySeparatorChar +
                DateTime.Now.ToString("yyy-MM-dd_HH-mm-ss") + ".jpg");
        }
    }
}
