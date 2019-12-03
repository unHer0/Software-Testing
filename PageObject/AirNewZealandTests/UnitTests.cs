using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AirNewZealandTests.WebPages;

namespace AirNewZealandTests
{
    [TestFixture]
    public class UnitTests
    {
        private IWebDriver driver;

        const string ERROR_TEXT_WHEN_ENTERING_SAME_CITY_OF_DEPARTURE_AND_ARRIVAL = "Please fill out this field";
        const string ERROR_TEXT_WHEN_SEARCHING_TICKET_FOR_ONE_ADULT_AND_TWO_INFANTS =
            "You can only make an online booking for 1 infant per adult, up to a maximum total of 9 passengers. " +
            "You will need to reserve a seat for any additional infants and pay a child's fare. Any additional infants " +
            "must be restrained in an approved infant car seat, which the accompanying adult(s) must provide.";

        [SetUp]
        public void OpenGoogleChromeBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.airnewzealand.com/");
        }
        [TearDown]
        public void CloseGoogleChromeBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }
        [Test]
        public void EnterTheSamePointOfDepartureAndArrival()
        {
            HomePage homePage = new HomePage(driver);
            SelectFlightPage selectFlightPage = homePage
                .ClearDepartureCity()
                .InputDepartureCity("Moscow")
                .InputArrivalCity("Moscow")
                .ClickOneWayLabel()
                .InputLeaveDate("12/24")
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_WHEN_ENTERING_SAME_CITY_OF_DEPARTURE_AND_ARRIVAL,
                    homePage.GetErrorMessage());
        }
        [Test]
        public void SearchingTicketForOneAdultAndTwoInfants()
        {
            HomePage homePage = new HomePage(driver);
            SelectFlightPage selectFlightPage = homePage
                .ClearDepartureCity()
                .InputDepartureCity("Auckland")
                .InputArrivalCity("Sydney")
                .ClickOneWayLabel()
                .ClickAddInfantsButton()
                .InputLeaveDate("12/24")
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_WHEN_SEARCHING_TICKET_FOR_ONE_ADULT_AND_TWO_INFANTS,
                    homePage.GetSecondErrorMessage());
        }
        [Test]
        public void SearchForTicketForTheYearAhead()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClearDepartureCity()
                .InputDepartureCity("Auckland")
                .InputArrivalCity("Sydney")
                .ClickOneWayLabel()
                .GetLastMonthInList();
            Assert.IsTrue(homePage.CellIsEnabledInCalendar());
        }
        [Test]
        public void SearchForTicketFromUnspecifiedTheCityOfDeparture()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClearDepartureCity()
                .InputArrivalCity("Sydney")
                .ClickOneWayLabel()
                .InputLeaveDate("12/24")
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_WHEN_ENTERING_SAME_CITY_OF_DEPARTURE_AND_ARRIVAL,
                homePage.GetErrorMessage());
        }
        [Test]
        public void SearchForTicketFromUnspecifiedTheDateOfDeparture()
        {
            HomePage homePage = new HomePage(driver);
            homePage.ClearDepartureCity()
                .InputDepartureCity("Auckland")
                .InputArrivalCity("Sydney")
                .ClickOneWayLabel()
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_WHEN_ENTERING_SAME_CITY_OF_DEPARTURE_AND_ARRIVAL,
                homePage.GetErrorMessage());
        }
    }
}
