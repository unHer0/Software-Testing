using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.PageObject
{
    public class HelpPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public HelpPage(IWebDriver driver)
        {
            this.driver = driver;
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(this.driver, this);
        }

        public string GetUrlHelpPage()
        {
            return driver.Url;
        }
    }
}
