using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.PageObject
{
    public class SelectFlightPage
    {
        private IWebDriver driver;

        public SelectFlightPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//fieldset/div[1]/div/div/div/div/div[1]/label/div[1]/div[2]/input")]
        private IWebElement selectedFlightInput;

        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement continueButton;

        public SelectFlightPage SelectFlight()
        {
            selectedFlightInput.Click();
            return this;
        }
        
        public PassengerDetailsPage ClickContinueButton()
        {
            continueButton.Click();
            return new PassengerDetailsPage(driver);
        }
    }
}
