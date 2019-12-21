using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.PageObject
{
    public class HelpPage
    {
        private IWebDriver driver;

        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        public HelpPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            Log.Info("Help Page initialized");
        }

        public string GetUrlHelpPage()
        {
            return driver.Url;
        }
    }
}
