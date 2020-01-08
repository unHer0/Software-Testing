using UnitTestProject.Service;
using NUnit.Framework;
using UnitTestProject.PageObjects;
using UnitTestProject.Driver;

namespace UnitTestProject.Tests
{
    public class Tests : CommonConditions
    {
        string url = "https://www.skyscanner.net/transport/flights-from/msq/200114/?adults=1&children=0&adultsv2=1&childrenv2=&infants=0&cabinclass=economy&rtn=0&preferdirects=false&outboundaltsenabled=false&inboundaltsenabled=false&ref=home";

        [Test]
        public void EnterTheSamePointOfDepartureAndArrival()
        {
            HomePage homePage = new HomePage();
            SelectFlightPage selectFlightPage = homePage
                .EnterDepartureCity(new RouteCreator().WithAllProperties())
                .EnterArrivalCity(new RouteCreator().WithAllProperties())
                .ChooseOneWayRoute()
                .OpenCalendar()
                .ChooseDepartDate(new RouteCreator().WithAllProperties())
                .ClickSearchButton();
            Assert.AreEqual(ErrorMessage.ERROR_TEXT_IF_ENTERED_SAME_CITIES,
                homePage.GetErrorMessage(ErrorMessage.ERROR_TEXT_IF_ENTERED_SAME_CITIES));
        }

        [Test]
        public void TicketSearchForOneAdultAndOneChildWithoutIndicatingHisAge()
        {
            HomePage homePage = new HomePage();
            SelectFlightPage selectFlightPage = homePage
                .EnterDepartureCity(new RouteCreator().WithAllProperties())
                .EnterArrivalCity(new RouteCreator().WithAllProperties())
                .ChooseOneWayRoute()
                .OpenCalendar()
                .ChooseDepartDate(new RouteCreator().WithAllProperties())
                .OpenPassengerInformation()
                .AddChildPassengers(1)
                .ClickDoneButton()
                .ClickSearchButton();
            Assert.AreEqual(ErrorMessage.ERROR_TEXT_IF_NOT_SPECIFIED_AGE_OF_CHILD,
                homePage.GetErrorMessage(ErrorMessage.ERROR_TEXT_IF_NOT_SPECIFIED_AGE_OF_CHILD));
        }

        [Test]
        public void TicketSearchForOneAdultAndTwoChildrenUnderTwoYearsOld()
        {
            HomePage homePage = new HomePage();
            SelectFlightPage selectFlightPage = homePage
                .EnterDepartureCity(new RouteCreator().WithAllProperties())
                .EnterArrivalCity(new RouteCreator().WithAllProperties())
                .ChooseOneWayRoute()
                .OpenCalendar()
                .ChooseDepartDate(new RouteCreator().WithAllProperties())
                .OpenPassengerInformation()
                .AddChildPassengers(2)
                .SetAllAge("1")
                .ClickDoneButton()
                .ClickSearchButton();
            Assert.AreEqual(ErrorMessage.ERROR_TEXT_IF_ONE_ADULT_AND_TWO_CHILDREN,
                homePage.GetErrorMessage(ErrorMessage.ERROR_TEXT_IF_ONE_ADULT_AND_TWO_CHILDREN));
        }

        [Test]
        public void TicketSearchWithoutCityOfArrival()
        {
            HomePage homePage = new HomePage();
            SelectFlightPage selectFlightPage = homePage
                .EnterDepartureCity(new RouteCreator().WithAllProperties())
                .ChooseOneWayRoute()
                .OpenCalendar()
                .ChooseDepartDate(new RouteCreator().WithAllProperties())
                .ClickSearchButton();
            Assert.AreEqual(url, DriverSingleton.GetDriver().Url);
        }

        [Test]
        public void SelectEightAdults()
        {
            HomePage homePage = new HomePage();
            homePage
                .EnterDepartureCity(new RouteCreator().WithAllProperties())
                .EnterArrivalCity(new RouteCreator().WithAllProperties())
                .ChooseOneWayRoute()
                .OpenCalendar()
                .ChooseDepartDate(new RouteCreator().WithAllProperties())
                .OpenPassengerInformation()
                .AddAdultPassenger(8);
            Assert.IsFalse(homePage.CheckAddAdultButton());
        }

        [Test]
        public void SelectDateEarlierThanCurrent()
        {
            HomePage homePage = new HomePage();
            homePage
                .EnterDepartureCity(new RouteCreator().WithAllProperties())
                .EnterArrivalCity(new RouteCreator().WithAllProperties())
                .ChooseOneWayRoute()
                .OpenCalendar();
            Assert.IsTrue(homePage.CheckDateThanEarlierCurrent());
        }


    }
}
