using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace EtoroEx
{
    public class CountriesPick : QuerySearch
    {
        


        private const string HierarchyList = "hierarchy-select";
        
        public static IWebElement CountryResults( string query,string country)
        {
            var searchBar = SearchDriver(query);
            IWebElement selectElement = searchBar.FindElement(By.ClassName(HierarchyList));
            selectElement.Click();
            Actions searchAction = new Actions(searchBar).MoveToElement(selectElement)
                .Click().SendKeys(country);
            searchAction.Perform();

            ///TODO: Fix Click On Districts
            IWebElement upDistrict = searchBar.FindElement(By.ClassName(Testbase.HierachyPick));
            Actions clickUpDistrict = new Actions(searchBar).MoveToElement(upDistrict).Click();
            clickUpDistrict.Perform();
            
            IWebElement districts = searchBar.FindElement(By.ClassName(Testbase.HierachyPickZoom));
            Actions clickDistricts = new Actions(searchBar).MoveToElement(districts).Click();
            clickDistricts.Perform();

            /// this area not coming back from the website///
            //SelectElement oSelectElement =
            //new SelectElement(searchBar.FindElement(By.ClassName("related-queries-combo-wrapper")));
            //var a = oSelectElement.Options;
            return selectElement;
        }
    }
}
