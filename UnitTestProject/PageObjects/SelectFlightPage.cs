using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using UnitTestProject.Driver;

namespace UnitTestProject.PageObjects
{
    public class SelectFlightPage
    {
        private IWebDriver driver;
        public SelectFlightPage()
        {
            driver = DriverSingleton.GetDriver();
            PageFactory.InitElements(driver, this);
            DriverSingleton.GetDriver().Url = 
                "https://www.skyscanner.net/transport/flights-from/msq/200114/?adults=1&children=0&adultsv2=1&childrenv2=&infants=0&cabinclass=economy&rtn=0&preferdirects=false&outboundaltsenabled=false&inboundaltsenabled=false&ref=home";
        }
    }
}
