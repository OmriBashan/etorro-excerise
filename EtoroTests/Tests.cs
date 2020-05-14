using EtoroEx;
using NUnit.Framework;
using OpenQA.Selenium;
using FluentAssertions;

namespace EtoroTests
{
    public class Tests : QuerySearch 
    {
        

        
        [SetUp]
        public void Setup()
        {
            
            
        }

        [Test]
        public static void SanityTest()
        {
           
            var hirerchy = CountriesPick.CountryResults(query:"query",country: "United Kingdom");
            

            //Assert;
        }
    }
}