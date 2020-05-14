using System;
using System.Threading;
using EtoroEx;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Selenium.WebDriver.WaitExtensions;


namespace EtoroEx
{
    public class QuerySearch : DriverSetup
    {
        public interface IQuerySearch
        {
            IWebDriver Driver();
        }
        public static IWebDriver SearchDriver(string query)
        {
            IWebDriver driver = DecideDriver();
            driver.Manage().Window.Maximize();
            IWebElement searchBarElement =
                driver.FindElement(By.CssSelector(Testbase.SearchBar));

            if (searchBarElement.Enabled.Equals(false))
            {
                throw new ElementNotInteractableException("the element cant be clicked");
            }

            SearchingQuery(query,driver, searchBarElement, out var searchAction);

            return driver;
        }

        private static void SearchingQuery(string query,IWebDriver driver, IWebElement searchBarElement, out Actions searchAction)
        {
            searchAction = new Actions(driver).MoveToElement(searchBarElement)
                .Click().SendKeys(query).SendKeys(Keys.Enter);
            searchAction.Perform();
        }
    }
}