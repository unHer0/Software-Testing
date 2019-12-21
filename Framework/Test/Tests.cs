using Framework.PageObject;
using Framework.Service;
using log4net;
using NUnit.Framework;

namespace Framework.Test
{
    public class Tests : CommonConditions
    {
        private const string ERROR_TEXT_IF_ENTERED_INCORRECTLY =
            "Please fill out this field";
        private const string ERROR_TEXT_WHEN_SEARCHING_TICKET_FOR_ONE_ADULT_AND_TWO_INFANTS =
            "You can only make an online booking for 1 infant per adult, up to a maximum total of 9 passengers. " +
            "You will need to reserve a seat for any additional infants and pay a child's fare. Any additional infants " +
            "must be restrained in an approved infant car seat, which the accompanying adult(s) must provide.";

        private const string ERROR_TEXT_WHEN_PASSENGER_IS_LESS_THAN_TWELVE_YEARS_OLD =
            "You have entered a passenger age of under 12 (at time of travel). " +
            "This passenger must travel as a child. Please amend your booking.";

        private const string ERROR_TEXT_WHEN_INVALID_EMAIL =
            "You have entered an invalid email address.";

        private const string HelpPageUrl = "https://www.airnewzealand.eu/help-and-contact";

        static private ILog Log = LogManager.GetLogger(typeof(Tests));

        [Test]
        public void EnterTheSamePointOfDepartureAndArrival()
        {
            RouteCreator routeCreator = new RouteCreator();
            HomePage homePage = new HomePage(driver);
            SelectFlightPage selectFlightPage = homePage
                .AcceptCookie()
                .EnterDepartureCity(routeCreator.WithAllProperties())
                .EnterArrivalCity(routeCreator.WithAllProperties())
                .SelectOneWayRoute()
                .EnterOneWayLeaveDate(routeCreator.WithAllProperties())
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_IF_ENTERED_INCORRECTLY,
                            homePage.GetToErrorMessageText());
        }

        [Test]
        public void SearchingTicketForOneAdultAndTwoInfants()
        {
            RouteCreator routeCreator = new RouteCreator();
            HomePage homePage = new HomePage(driver);
            SelectFlightPage selectFlightPage = homePage
                .AcceptCookie()
                .EnterDepartureCity(routeCreator.WithAllProperties())
                .EnterArrivalCity(routeCreator.WithAllProperties())
                .SelectOneWayRoute()
                .EnterOneWayLeaveDate(routeCreator.WithAllProperties())
                .ClickAddInfantsButton(2)
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_WHEN_SEARCHING_TICKET_FOR_ONE_ADULT_AND_TWO_INFANTS,
                            homePage.GetPaxCountsErrorMessageText());
        }

        [Test]
        public void SearchForTicketFromUnspecifiedTheCityOfDeparture()
        {
            RouteCreator routeCreator = new RouteCreator();
            HomePage homePage = new HomePage(driver);
            SelectFlightPage selectFlightPage = homePage
                .AcceptCookie()
                .EnterDepartureCity(routeCreator.WithEmptyDeparture())
                .EnterArrivalCity(routeCreator.WithAllProperties())
                .SelectOneWayRoute()
                .EnterOneWayLeaveDate(routeCreator.WithAllProperties())
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_IF_ENTERED_INCORRECTLY,
                            homePage.GetFromErrorMessageText());
        }

        [Test]
        public void SearchForTicketFromUnspecifiedTheDateOfDeparture()
        {
            RouteCreator routeCreator = new RouteCreator();
            HomePage homePage = new HomePage(driver);
            SelectFlightPage selectFlightPage = homePage
                .AcceptCookie()
                .EnterDepartureCity(routeCreator.WithAllProperties())
                .EnterArrivalCity(routeCreator.WithAllProperties())
                .SelectOneWayRoute()
                .EnterOneWayLeaveDate(routeCreator.WithEmptyLeaveData())
                .ClickTicketsSearchButton();
            Assert.AreEqual(ERROR_TEXT_IF_ENTERED_INCORRECTLY,
                            homePage.GetLeaveDateErrorMessageText());
        }

        [Test]
        public void TicketBookingForPassengerWhoIsLessThanTwelveYearsOld()
        {
            RouteCreator routeCreator = new RouteCreator();
            PassengerCreator passengerCreator = new PassengerCreator();
            HomePage homePage = new HomePage(driver);
            PassengerDetailsPage passengerDetailsPage = homePage
                .AcceptCookie()
                .EnterDepartureCity(routeCreator.WithAllProperties())
                .EnterArrivalCity(routeCreator.WithAllProperties())
                .SelectOneWayRoute()
                .EnterOneWayLeaveDate(routeCreator.WithAllProperties())
                .ClickTicketsSearchButton()
                .SelectFlight()
                .ClickContinueButton()
                .ChooseTitle()
                .EnterFirstName(passengerCreator.WithAllProperties())
                .EnterFamilyName(passengerCreator.WithAllProperties())
                .ChooseDayOfBirth(passengerCreator.WithAllProperties())
                .ChooseMonthOfBirth(passengerCreator.WithAllProperties())
                .ChooseYearOfBirth(passengerCreator.WithInvalidYearOfBirth())
                .ChooseLandline(passengerCreator.WithAllProperties())
                .EnterMobilePhone(passengerCreator.WithAllProperties())
                .EnterEmail(passengerCreator.WithAllProperties())
                .ChooseCountry(passengerCreator.WithAllProperties())
                .ClickContinueButton();
            Assert.AreEqual(ERROR_TEXT_WHEN_PASSENGER_IS_LESS_THAN_TWELVE_YEARS_OLD,
                            passengerDetailsPage.GetDateOfBirthErrorMessageText());
        }

        [Test]
        public void FlightsReturnDateIsNotEnabledWhenSearchBookFlightsOnTheOneWay()
        {
            RouteCreator routeCreator = new RouteCreator();
            HomePage homePage = new HomePage(driver)
                .AcceptCookie()
                .EnterArrivalCity(routeCreator.WithAllProperties())
                .SelectOneWayRoute();
            Assert.IsFalse(homePage.FlightsReturnDateIsEnabled());
        }

        [Test]
        public void CheckHelpPage()
        {
            RouteCreator routeCreator = new RouteCreator();
            HelpPage helpPage = new HomePage(driver)
                .AcceptCookie()
                .GoToHelpPage();
            Assert.AreEqual(helpPage.GetUrlHelpPage(), HelpPageUrl);
        }

        [Test]
        public void TicketBookingForPassengerWithInvalidEmail()
        {
            RouteCreator routeCreator = new RouteCreator();
            PassengerCreator passengerCreator = new PassengerCreator();
            HomePage homePage = new HomePage(driver);
            PassengerDetailsPage passengerDetailsPage = homePage
                .AcceptCookie()
                .EnterDepartureCity(routeCreator.WithAllProperties())
                .EnterArrivalCity(routeCreator.WithAllProperties())
                .SelectOneWayRoute()
                .EnterOneWayLeaveDate(routeCreator.WithAllProperties())
                .ClickTicketsSearchButton()
                .SelectFlight()
                .ClickContinueButton()
                .ChooseTitle()
                .EnterFirstName(passengerCreator.WithAllProperties())
                .EnterFamilyName(passengerCreator.WithAllProperties())
                .ChooseDayOfBirth(passengerCreator.WithAllProperties())
                .ChooseMonthOfBirth(passengerCreator.WithAllProperties())
                .ChooseYearOfBirth(passengerCreator.WithAllProperties())
                .ChooseLandline(passengerCreator.WithAllProperties())
                .EnterMobilePhone(passengerCreator.WithAllProperties())
                .EnterEmail(passengerCreator.WithInvalidEmail())
                .ChooseCountry(passengerCreator.WithAllProperties())
                .ClickContinueButton();
            Assert.AreEqual(ERROR_TEXT_WHEN_INVALID_EMAIL,
                            passengerDetailsPage.GetEmailErrorMessageText());
        }

        [Test]
        public void SearchWithoutEnteringInformationTest()
        {
            HomePage homePage = new HomePage(driver);
            SelectFlightPage selectFlightsPage = homePage
                .AcceptCookie()
                .ClickTicketsSearchButton();
            Assert.AreEqual(homePage.GetToErrorMessageText(), ERROR_TEXT_IF_ENTERED_INCORRECTLY);
        }
    }
}
