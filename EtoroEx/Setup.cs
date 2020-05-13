using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace EtoroEx
{
    public class Setup
    {
        protected static string InitDriver {get;set;}
        protected static string DriverType { get; set;}
        protected static string URL { get; set; }

        public Setup()
        {
            ConfigurationBuilder();
            
        }
        public static JToken ConfigurationBuilder(string changingDriver = "ChromeDriver")
        {
            StreamReader file = File.OpenText("test.json");
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);
                try
                {
                    InitDriver = o2.GetValue(changingDriver).ToString();
                    DriverType = changingDriver;
                    URL = o2.GetValue("URL").ToString();

                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("Didn't choose driver");
                    
                }
                return InitDriver;
            }
        }
    }
}