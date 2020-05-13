using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace EtoroEx
{
    public class DriverSetup :Setup
    {
        public static IWebDriver decideDriver { get; set;}
        public static IWebDriver DecideDriver()
        {
            if (DriverType.Equals("ChromeDriver"))
            {
                OpenChrome();
            }
            else
            {
                if (DriverType.Equals("FireFox"))
                {
                    OpenFireFox();
                }
            }
            return decideDriver;
        }

        private static void OpenFireFox()
        {
            decideDriver = new FirefoxDriver(InitDriver);
            URLDriver(decideDriver);
        }

        private static void OpenChrome()
        {
            decideDriver = new ChromeDriver(InitDriver);
            URLDriver(decideDriver);
        }

        public static IWebDriver URLDriver(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(URL);
            return driver;
        }

    }
}