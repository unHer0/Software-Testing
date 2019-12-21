using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Framework.Models;
using System.Diagnostics;
using System;
using log4net;

namespace Framework.PageObject
{
    public class PassengerDetailsPage
    {
        private IWebDriver driver;

        private static ILog Log = LogManager.GetLogger(typeof(TestListener));

        public PassengerDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            Log.Info("Passenger Details Page initialized");
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].title']")]
        private IWebElement titleSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].firstName']")]
        private IWebElement firstNameInputField;

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].surname']")]
        private IWebElement familyNameInputField;

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].birthDateDay']")]
        private IWebElement dayOfBirthSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].birthDateMonth']")]
        private IWebElement monthOfBirthSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].birthDateYear']")]
        private IWebElement yearOfBirthSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].birthDate-error']")]
        private IWebElement dateOfBirthErrorMessageDiv;

        [FindsBy(How = How.Id, Using = "emailAddress-error")]
        private IWebElement EmailErrorMessageDiv;

        [FindsBy(How = How.Name, Using = "phone-countrycode")]
        private IWebElement landlineSelect;

        [FindsBy(How = How.XPath, Using = "//*[@id='travellers[0].phoneNumber']")]
        private IWebElement mobilePhoneInputField;

        [FindsBy(How = How.Id, Using = "emailAddress")]
        private IWebElement emailInputField;

        [FindsBy(How = How.Id, Using = "field-countryOfResidence")]
        private IWebElement countrySelect;

        [FindsBy(How = How.Id, Using = "submitBtn")]
        private IWebElement continueButton;

        public PassengerDetailsPage ChooseTitle()
        {
            SelectElement selectElement = new SelectElement(titleSelect);
            selectElement.SelectByIndex(0);
            Log.Info("Choose Title");
            return this;
        }

        public PassengerDetailsPage EnterFirstName(Passenger passenger)
        {
            firstNameInputField.SendKeys(passenger.FirstName);
            Log.Info($"Enter First Name : {passenger.FirstName}");
            return this;
        }

        public PassengerDetailsPage EnterFamilyName(Passenger passenger)
        {
            familyNameInputField.SendKeys(passenger.FamilyName);
            Log.Info($"Enter Family Name : {passenger.FamilyName}");
            return this;
        }

        public PassengerDetailsPage ChooseDayOfBirth(Passenger passenger)
        {
            SelectElement selectElement = new SelectElement(dayOfBirthSelect);
            selectElement.SelectByText(passenger.DayOfBirth);
            Log.Info($"Choose Birth Day : {passenger.DayOfBirth}");
            return this;
        }

        public PassengerDetailsPage ChooseMonthOfBirth(Passenger passenger)
        {
            SelectElement selectElement = new SelectElement(monthOfBirthSelect);
            selectElement.SelectByText(passenger.MonthOfBirth);
            Log.Info($"Choose Birth Month : {passenger.MonthOfBirth}");
            return this;
        }

        public PassengerDetailsPage ChooseYearOfBirth(Passenger passenger)
        {
            SelectElement selectElement = new SelectElement(yearOfBirthSelect);
            selectElement.SelectByText(passenger.YearOfBirth);
            Log.Info($"Choose Birth Year : {passenger.YearOfBirth}");
            return this;
        }

        public string GetDateOfBirthErrorMessageText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (dateOfBirthErrorMessageDiv.Text != String.Empty)
                    return dateOfBirthErrorMessageDiv.Text;
            }
            Log.Info("Get Date Of Birth Error Message Text");
            return " ";
        }

        public string GetEmailErrorMessageText()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds <= 10000)
            {
                if (EmailErrorMessageDiv.Text != String.Empty)
                    return EmailErrorMessageDiv.Text;
            }
            Log.Info("Get Email Error Message Text");
            return " ";
        }

        public PassengerDetailsPage ChooseLandline(Passenger passenger)
        {
            SelectElement selectElement = new SelectElement(landlineSelect);
            selectElement.SelectByText(passenger.Landline);
            Log.Info($"Choose Landline : {passenger.Landline}");
            return this;
        }

        public PassengerDetailsPage EnterMobilePhone(Passenger passenger)
        {
            mobilePhoneInputField.SendKeys(passenger.MobilePhone);
            Log.Info($"Enter Mobile Phone : {passenger.MobilePhone}");
            return this;
        }

        public PassengerDetailsPage EnterEmail(Passenger passenger)
        {
            emailInputField.SendKeys(passenger.Email);
            Log.Info($"Enter Email : {passenger.Email}");
            return this;
        }

        public PassengerDetailsPage ChooseCountry(Passenger passenger)
        {
            SelectElement selectElement = new SelectElement(countrySelect);
            selectElement.SelectByText(passenger.Country);
            Log.Info($"Choose Country : {passenger.Country}");
            return this;
        }

        public PassengerDetailsPage ClickContinueButton()
        {
            continueButton.Click();
            Log.Info($"Click Continue Button");
            return new PassengerDetailsPage(driver);
        }
    }
}
