using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.PageObject
{
    public class PlanPage
    {
        private IWebDriver driver;

        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        public PlanPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            Log.Info("Plan Page initialized");
        }

        public string GetUrlPlanPage()
        {
            return driver.Url;
        }
    }
}
