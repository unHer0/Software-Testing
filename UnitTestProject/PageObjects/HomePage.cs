using System;
using System.Diagnostics;
using UnitTestProject.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using log4net;
using System.Collections.ObjectModel;
using UnitTestProject.Driver;
using UnitTestProject.Tests;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        private const string PageUrl = "https://www.skyscanner.net/";

        public HomePage()
        {
            driver = DriverSingleton.GetDriver();
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(PageUrl);
        }

        [FindsBy(How = How.Id, Using = "fsc-origin-search")]
        private IWebElement departureCityInputField;

        [FindsBy(How = How.Id, Using = "fsc-destination-search")]
        private IWebElement arrivalCityInputField;

        [FindsBy(How = How.Id, Using = "fsc-trip-type-selector-one-way")]
        private IWebElement oneWayRadioButton;

        [FindsBy(How = How.Id, Using = "depart-fsc-datepicker-button")]
        private IWebElement departCalendarButton;

        [FindsBy(How = How.Name, Using = "class-travellers-trigger")]
        private IWebElement passengersButton;

        private ReadOnlyCollection<IWebElement> allDates;
        private void GetAllDates()
        {
            allDates = GetWebElementsByXPath("//*[@id='depart-fsc-datepicker-popover']//td");
        }

        private ReadOnlyCollection<IWebElement> allSelects;
        private void GetAllSelects()
        {
            allSelects = GetWebElementsByXPath("//*[@id='cabin-class-travellers-popover']/div/div/div//select");
        }

        private IWebElement searchButton;
        private void GetSearchButton()
        {
            searchButton = GetWebElementByXPath("//*[@id='flights-search-controls-root']/div/div/form/div[3]/button");
        }

        private IWebElement elementThatContainsErrorMessage;
        private void GetElementThatContainsErrorMessage()
        {
            elementThatContainsErrorMessage = GetWebElementByXPath("//*[@id='flights-search-controls-root']/div/div/form/div[2]/div");
        }
        private IWebElement addChildLikePassengerButton;
        private void GetAddChildLikePassengerButton()
        {
            addChildLikePassengerButton = GetWebElementByXPath("//*[@id='cabin-class-travellers-popover']/div/div/div[2]//button[2]");
        }
        private IWebElement doneButton;
        private void GetDoneButton()
        {
            doneButton = GetWebElementByXPath("//*[@id='cabin-class-travellers-popover']/footer/button");
        }
        private IWebElement addAdultButton;
        private void GetAddAdultButton()
        {
            addAdultButton = GetWebElementByXPath("//*[@id='cabin-class-travellers-popover']/div/div/div[1]/div/button[2]");
        }

        public HomePage EnterDepartureCity(Route route)
        {
            departureCityInputField.Clear();
            departureCityInputField.SendKeys(route.Departure + Keys.Enter);
            return this;
        }

        public HomePage EnterArrivalCity(Route route)
        {
            arrivalCityInputField.Clear();
            arrivalCityInputField.SendKeys(route.Arrival + Keys.Enter);
            return this;
        }

        public HomePage ChooseOneWayRoute()
        {
            oneWayRadioButton.Click();
            return this;
        }

        public HomePage OpenCalendar()
        {
            departCalendarButton.Click();
            return this;
        }

        public HomePage ChooseDepartDate(Route route)
        {
            GetAllDates();
            foreach (IWebElement date in allDates)
            {
                if (route.LeaveDate.Equals(date.Text))
                {
                    date.Click();
                    break;
                }
            }
            return this;
        }

        public HomePage OpenPassengerInformation()
        {
            passengersButton.Click();
            return this;
        }

        public HomePage AddChildPassengers(int count)
        {
            GetAddChildLikePassengerButton();
            for (int i = 0; i < count; i++)
            {
                addChildLikePassengerButton.Click();
            }
            return this;
        }

        public HomePage ClickDoneButton()
        {
            GetDoneButton();
            doneButton.Click();
            return this;
        }

        public HomePage SetAllAge(string age)
        {
            GetAllSelects();
            foreach (IWebElement select in allSelects)
            {
                SelectElement selectElement = new SelectElement(select);
                selectElement.SelectByText(age);
            }
            return this;
        }

        public HomePage AddAdultPassenger(int count)
        {
            GetAddAdultButton();
            for (int i = 0; i < count; i++)
            {
                addAdultButton.Click();
            }
            return this;
        }

        public bool CheckAddAdultButton()
        {
            GetAddAdultButton();
            return addAdultButton.Enabled;
        }

        public bool CheckDateThanEarlierCurrent()
        {
            GetAllDates();
            foreach (IWebElement date in allDates)
            {
                if (date.Text.Equals("31"))
                {
                    return date.Enabled;
                }
            }
            return false;
        }

        public SelectFlightPage ClickSearchButton()
        {
            GetSearchButton();
            searchButton.Click();
            return new SelectFlightPage();
        }

        public string GetErrorMessage(string message)
        {
            GetElementThatContainsErrorMessage();
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (elementThatContainsErrorMessage.Text.Equals(message))
                    return elementThatContainsErrorMessage.Text;
            }
            return " ";
        }

        private IWebElement GetWebElementByXPath(string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }
        private ReadOnlyCollection<IWebElement> GetWebElementsByXPath(string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }
    }
}
