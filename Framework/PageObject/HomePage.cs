using System;
using System.Diagnostics;
using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using log4net;

namespace Framework.PageObject
{
    public class HomePage
    {
        private IWebDriver driver;
        private readonly string Url = "https://www.airnewzealand.eu/";
        private static ILog Log = LogManager.GetLogger(typeof(TestListener));
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            this.driver.Navigate().GoToUrl(Url);
            Log.Info($"Home Page initialized");
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

        [FindsBy(How = How.XPath, Using = "//*[@id='masthead-nav']/div/div/div/div/nav/div[2]/div[1]/div[1]/div[1]/div/a")]
        private IWebElement PlanButton;

        private IWebElement GetAcceptCookieButton() => driver.FindElement(By.XPath("//*[@id='cookie-consent-explicit-modal']//button"));

        private IWebElement GetOneWayLabel() => driver.FindElements(By.ClassName("radio-inline"))[1];

        public HomePage EnterDepartureCity(Route route)
        {
            departureCityInputField.Clear();
            departureCityInputField.SendKeys(route.Departure);
            Log.Info($"Enter Departure City: {route.Departure}");
            return this;
        }

        public HomePage EnterArrivalCity(Route route)
        {
            arrivalCityInputField.Clear();
            arrivalCityInputField.SendKeys(route.Arrival);
            Log.Info($"Enter Arrival City: {route.Arrival}");
            return this;
        }

        public HomePage SelectOneWayRoute()
        {
            GetOneWayLabel().Click();
            Log.Info($"Select OneWay Route");
            return this;
        }

        public HomePage EnterOneWayLeaveDate(Route route)
        {
            leaveDateInputField.SendKeys(route.LeaveDate);
            Log.Info($"Enter OneWay LeaveDate: {route.LeaveDate}");
            return this;
        }

        public HomePage ClickAddInfantsButton(int numberOfClicks)
        {
            for (int i = 0; i < numberOfClicks; i++)
            {
                addInfantButton.Click();
            }
            Log.Info($"Click Add Infants Button {numberOfClicks} times");
            return this;
        }

        public SelectFlightPage ClickTicketsSearchButton()
        {
            ticketsSearchButton.Click();
            Log.Info("Click Tickets Search Button");
            return new SelectFlightPage(driver);
        }

        public HelpPage GoToHelpPage()
        {
            HelpButton.Click();
            Log.Info("Go To Help Page");
            return new HelpPage(driver);
        }

        public PlanPage GoToPlanPage()
        {
            PlanButton.Click();
            Log.Info("Go To Plan Page");
            return new PlanPage(driver);
        }

        public string GetToErrorMessageText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (toErrorMessageDiv.Text != String.Empty)
                    return toErrorMessageDiv.Text;
            }
            Log.Info("Get To Error Message Text");
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
            Log.Info("Get PaxCounts Error Message Text");
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
            Log.Info("Get From Error Message Text");
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
            Log.Info("Get Leave Date Error Message Text");
            return " ";
        }

        public HomePage AcceptCookie()
        {
            GetAcceptCookieButton().Click();
            Log.Info("Accept Cookie");
            return this;
        }

        public bool FlightsReturnDateIsEnabled()
        {
            return returnDateInputField.Enabled;
        }
    }
}
