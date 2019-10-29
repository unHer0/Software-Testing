using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver
{
    [TestFixture]
    class AirNewZealandTests : BrowserSetUp
    {
        const string ERROR_TEXT_WHEN_ENTERING_SAME_CITY_OF_DEPARTURE_AND_ARRIVAL = "Please fill out this field";
        const string ERROR_TEXT_WHEN_SEARCHING_TICKET_FOR_ONE_ADULT_AND_TWO_INFANTS =
            "You can only make an online booking for 1 infant per adult, up to a maximum total of 9 passengers. " +
            "You will need to reserve a seat for any additional infants and pay a child's fare. Any additional infants " +
            "must be restrained in an approved infant car seat, which the accompanying adult(s) must provide.";
        [Test]
        public void EnterTheSamePointOfDepartureAndArrival()
        {
            const string DEPARTURE_CITY_TEXT = "Moscow";
            const string ARRIVAL_CITY_TEXT = "Moscow";
            const string DEPARTURE_DATE_TEXT = "11/24";

            var departureCityInput = GetElementById("depart-from");
            var arrivalCityInput = GetElementById("depart-to");
            var journeyTypes = GetElementsByClassName("radio-inline");
            var oneWayLabel = journeyTypes[1];
            var leaveDateInput = GetElementById("leaveDate");
            var errorMessageDiv = GetElementById("toSelectedOption-error");

            departureCityInput.Clear();
            arrivalCityInput.SendKeys(ARRIVAL_CITY_TEXT);
            departureCityInput.SendKeys(DEPARTURE_CITY_TEXT);
            oneWayLabel.Click();
            leaveDateInput.SendKeys(DEPARTURE_DATE_TEXT);
            var ticketSearchButton = GetElementByName("search");
            ticketSearchButton.Click();
            WaitingForTextToAppear(errorMessageDiv);
            Assert.AreEqual(ERROR_TEXT_WHEN_ENTERING_SAME_CITY_OF_DEPARTURE_AND_ARRIVAL, errorMessageDiv.Text);
        }

        [Test]
        public void SearchingTicketForOneAdultAndTwoInfants()
        {
            const string DEPARTURE_CITY_TEXT = "Auckland";
            const string ARRIVAL_CITY_TEXT = "Sydney";
            const string DEPARTURE_DATE_TEXT = "11/24";

            var departureCityInput = GetElementById("depart-from");
            var arrivalCityInput = GetElementById("depart-to");
            var journeyTypes = GetElementsByClassName("radio-inline");
            var oneWayLabel = journeyTypes[1];
            var leaveDateInput = GetElementById("leaveDate");
            var ticketSearchButton = GetElementByName("search");
            var addInfantsButton = GetElementByName("add infant");
            var errorMessageDiv = GetElementById("paxCounts-error");

            departureCityInput.Clear();
            arrivalCityInput.SendKeys(ARRIVAL_CITY_TEXT);
            departureCityInput.SendKeys(DEPARTURE_CITY_TEXT);
            oneWayLabel.Click();
            addInfantsButton.Click();
            leaveDateInput.SendKeys(DEPARTURE_DATE_TEXT);
            addInfantsButton.Click();
            ticketSearchButton.Click();

            WaitingForTextToAppear(errorMessageDiv);
            Assert.AreEqual(ERROR_TEXT_WHEN_SEARCHING_TICKET_FOR_ONE_ADULT_AND_TWO_INFANTS, errorMessageDiv.Text);
        }
    }
}
