using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.PageObject
{
    public class ExtrasPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='main-container']/vbk-extraspage/div/form/div[4]/div/button")]
        private IWebElement continueButton;

        public ExtrasPage ClickContinueButton()
        {
            continueButton.Click();
            return this;
        }

        public ExtrasPage()
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

    }
}
