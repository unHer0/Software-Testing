using System;
using System.Diagnostics;
using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.PageObject
{
    public class HomePage
    {
        private IWebDriver driver;
        private readonly string Url = "https://www.airnewzealand.eu/";
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            this.driver.Navigate().GoToUrl(Url);
        }

        [FindsBy(How = How.Id, Using = "depart-from")]
        private IWebElement departureCityInputField;

        [FindsBy(How = How.Id, Using = "depart-to")]
        private IWebElement arrivalCityInputField;

        [FindsBy(How = How.Id, Using = "leaveDate")]
        private IWebElement leaveDateInputField;

        [FindsBy(How = How.Name, Using = "search")]
        private IWebElement ticketsSearchButton;

        [FindsBy(How = How.Id, Using = "toSelectedOption-error")]
        private IWebElement toErrorMessageDiv;

        [FindsBy(How = How.Name, Using = "add infant")]
        private IWebElement addInfantButton;

        [FindsBy(How = How.Id, Using = "paxCounts-error")]
        private IWebElement paxCountsErrorMessageDiv;

        [FindsBy(How = How.Id, Using = "fromSelectedOption-error")]
        private IWebElement fromErrorMessageDiv;

        [FindsBy(How = How.Id, Using = "leaveDate-error")]
        private IWebElement leaveDateErrorMessageDiv;

        [FindsBy(How = How.Id, Using = "returnDate")]
        private IWebElement returnDateInputField;

        [FindsBy(How = How.Id, Using = "page-mb-219641")]
        private IWebElement HelpButton;

        private IWebElement GetAcceptCookieButton() => driver.FindElement(By.XPath("//*[@id='cookie-consent-explicit-modal']//button"));

        private IWebElement GetOneWayLabel() => driver.FindElements(By.ClassName("radio-inline"))[1];

        public HomePage EnterDepartureCity(Route route)
        {
            departureCityInputField.Clear();
            departureCityInputField.SendKeys(route.Departure);
            return this;
        }

        public HomePage EnterArrivalCity(Route route)
        {
            arrivalCityInputField.Clear();
            arrivalCityInputField.SendKeys(route.Arrival);
            return this;
        }

        public HomePage SelectOneWayRoute()
        {
            GetOneWayLabel().Click();
            return this;
        }

        public HomePage EnterOneWayLeaveDate(Route route)
        {
            leaveDateInputField.SendKeys(route.LeaveDate);
            return this;
        }

        public HomePage ClickAddInfantsButton(int numberOfClicks)
        {
            for (int i = 0; i < numberOfClicks; i++)
            {
                addInfantButton.Click();
            }
            return this;
        }

        public SelectFlightPage ClickTicketsSearchButton()
        {
            ticketsSearchButton.Click();
            return new SelectFlightPage(driver);
        }

        public HelpPage GoToHelpPage()
        {
            HelpButton.Click();
            return new HelpPage(driver);
        }

        public string GetToErrorMessageText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (toErrorMessageDiv.Text != String.Empty)
                    return toErrorMessageDiv.Text;
            }
            return " ";
        }

        public string GetPaxCountsErrorMessageText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (paxCountsErrorMessageDiv.Text != String.Empty)
                    return paxCountsErrorMessageDiv.Text;
            }
            return " ";
        }

        public string GetFromErrorMessageText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (fromErrorMessageDiv.Text != String.Empty)
                    return fromErrorMessageDiv.Text;
            }
            return " ";
        }

        public string GetLeaveDateErrorMessageText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (leaveDateErrorMessageDiv.Text != String.Empty)
                    return leaveDateErrorMessageDiv.Text;
            }
            return " ";
        }

        public HomePage AcceptCookie()
        {
            GetAcceptCookieButton().Click();
            return this;
        }

        public bool FlightsReturnDateIsEnabled()
        {
            return returnDateInputField.Enabled;
        }
    }
}
