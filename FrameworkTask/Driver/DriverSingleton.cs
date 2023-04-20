using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FrameworkTask.Driver
{
    public class DriverSingleton
    {
        private static DriverSingleton? instance;
        private static IWebDriver? driver;

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
                            driver = new FirefoxDriver();
                            break;
                        }
                    default:
                        {
                            driver = new ChromeDriver();
                            break;
                        }
                }
            }

            return instance;
        }

        public IWebDriver? GetDriver
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
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(Directory.GetCurrentDirectory() +
                    Path.DirectorySeparatorChar +
                    DateTime.Now.ToString("yyy-MM-dd_HH-mm-ss") + ".jpg");
            }
            catch 
            {
                
            }
        }
    }
}
