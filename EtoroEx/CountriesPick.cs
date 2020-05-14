using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace EtoroEx
{
    public class CountriesPick : QuerySearch
    {
        public static IWebElement CountryResults( string query,string country)
        {
            var searchBar = SearchBarNavigation(query, country, out var selectElement);

            ///TODO:add waiter until updistrict appeard

            var upDistrict = searchCountry(country, searchBar, out var clickUpDistrict);

            ///TODO:add wiater to wait (implicit wait)
            //List<string> districts = new List<string>();
            //Thread.Sleep(2000);
            //IWebElement options = upDistrict.FindElement(By.TagName("span"));
            //var hu = options.GetAttribute("innerText");

            ////IList<IWebElement> options = upDistrict.FindElements(By.CssSelector(Testbase.DistrictItemRelated));
            ////foreach (var a2 in options)
            ////{
            ////   string lol = a2.GetAttribute("innerText");
            ////    districts.Add(lol);
            ////}

            //Thread.Sleep(5000);
            //IWebElement AllDistricts = searchBar.FindElement(By.ClassName(Testbase.DistrictItemRelated));
            //string a = upDistrict.GetAttribute("innerText");

            return selectElement;
        }

        private static IWebDriver SearchBarNavigation(string query, string country, out IWebElement selectElement)
        {
            var searchBar = SearchDriver(query);
            selectElement = searchBar.FindElement(By.ClassName(Testbase.HierarchyList));
            selectElement.Click();
            Actions searchAction = new Actions(searchBar).MoveToElement(selectElement)
                .Click();
            searchAction.Perform();
            searchAction.SendKeys(country);
            searchAction.Perform();
            searchAction.Click();
            return searchBar;
        }

        private static IWebElement searchCountry(string country, IWebDriver searchBar, out Actions clickUpDistrict)
        {
            IWebElement upDistrict = searchBar.FindElement(By.ClassName(Testbase.HierachyPick));
            string countryNameAttribute = upDistrict.GetAttribute("innerText");
            CheckCountryExsist(country, countryNameAttribute);
            clickUpDistrict = new Actions(searchBar).MoveToElement(upDistrict);
            clickUpDistrict.Click();
            clickUpDistrict.Perform();
            return upDistrict;
        }

        private static void CheckCountryExsist(string country, string countryNameAttribute)
        {
            if (!countryNameAttribute.Contains(country))
            {
                throw new Exception("The County not appeared in the search");
            }
        }
    }
}
