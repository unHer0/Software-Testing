using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UnitTestProject.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver driver;
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                switch (TestContext.Parameters.Get("browser"))
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new FirefoxConfig());
						FirefoxOptions options = new FirefoxOptions();
						options.BrowserExecutableLocation = ("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
                        driver = new FirefoxDriver(options);
                        break;
                }
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);
            }
            Log.Info("Driver initialized");
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            Log.Info("Driver closed");
            driver = null;
        }
    }
}
