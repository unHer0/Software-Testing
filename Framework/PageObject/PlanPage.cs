using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.PageObject
{
    public class PlanPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public PlanPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public string GetUrlPlanPage()
        {
            return driver.Url;
        }
    }
}
