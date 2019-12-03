using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace AirNewZealandTests.WebPages
{
    class SelectFlightPage
    {
        private IWebDriver driver;
        public SelectFlightPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
    }
}
