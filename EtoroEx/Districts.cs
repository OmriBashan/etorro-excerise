using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace EtoroEx
{
    class Districts : QuerySearch
    {
        public static IList<IWebElement> CountryDistricts(string query)
        {
            IWebDriver districtDriver = SearchDriver(query);
            IList<IWebElement> options = districtDriver.FindElements(By.ClassName(Testbase.DistrictItemRelated));
            var a = options.Count;

            return options;
        }
    }
}
