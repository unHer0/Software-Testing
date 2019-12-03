using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace AirNewZealandTests.WebPages
{
	internal class HomePage
	{
		private IWebDriver driver;

		[FindsBy(How = How.Id, Using = "depart-from")]
		private IWebElement departureCityInput;

		[FindsBy(How = How.Id, Using = "depart-to")]
		private IWebElement arrivalCityInput;

        [FindsBy(How = How.Id, Using = "leaveDate")]
		private IWebElement leaveDateInput;

		[FindsBy(How = How.Id, Using = "toSelectedOption-error")]
		private IWebElement errorMessageDiv;

        [FindsBy(How = How.Id, Using = "paxCounts-error")]
        private IWebElement secondErrorMessageDiv;

        [FindsBy(How = How.Name, Using = "search")]
		private IWebElement ticketsSearchButton;

        [FindsBy(How = How.Name, Using = "add infant")]
        private IWebElement addInfantsButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='calendarpanel-5']/div[1]/div/select")]
        private IWebElement monthsSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='calendarpanel-5']/div[2]/table")]
        private IWebElement calendarTable;

        public HomePage(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
			this.driver = driver;
		}
        public HomePage ClearDepartureCity()
        {
            departureCityInput.Clear();
            return this;
        }
        public HomePage InputDepartureCity(string departureCity)
        {
            departureCityInput.SendKeys(departureCity);
            return this;
        }
        public HomePage InputArrivalCity(string arrivalCity)
        {
            arrivalCityInput.SendKeys(arrivalCity);
            return this;
        }
        public HomePage ClickOneWayLabel()
        {
            GetOneWayLabel().Click();
            return this;
        }
        public HomePage InputLeaveDate(string departureDate)
        {
            leaveDateInput.SendKeys(departureDate);
            return this;
        }
        public SelectFlightPage ClickTicketsSearchButton()
        {
            ticketsSearchButton.Click();
            return new SelectFlightPage(driver);
        }
        public string GetErrorMessage()
        {
            while (errorMessageDiv.Text == String.Empty)
            {

            }
            return errorMessageDiv.Text;
        }
        public string GetSecondErrorMessage()
        {
            while (secondErrorMessageDiv.Text == String.Empty)
            {

            }
            return secondErrorMessageDiv.Text;
        }
        public IWebElement GetOneWayLabel()
        {
            ReadOnlyCollection<IWebElement> TripsTypes =
                driver.FindElements(By.ClassName("radio-inline"));
            return TripsTypes[1];
        }
        public HomePage ClickAddInfantsButton()
        {
            addInfantsButton.Click();
            addInfantsButton.Click();
            return this;
        }
        public HomePage GetLastMonthInList()
        {
            SelectElement select = new SelectElement(monthsSelect);
            select.SelectByText("November 2020");
            return this;
        }
        public bool CellIsEnabledInCalendar()
        {
            ReadOnlyCollection<IWebElement> allRows = calendarTable.FindElements(By.TagName("tr"));
            foreach (var row in allRows)
            {
                ReadOnlyCollection<IWebElement> allCells = row.FindElements(By.TagName("td"));
                foreach (var cell in allCells)
                {
                    if (cell.Text == "3" && cell.GetAttribute("class").Contains("unselectable"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}