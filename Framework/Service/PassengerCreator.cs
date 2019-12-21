using Framework.Models;

namespace Framework.Service
{
    public class PassengerCreator
    {
        public Passenger WithAllProperties()
        {
            return new Passenger(TestDataReader.GetData("FirstName"),
                                TestDataReader.GetData("FamilyName"),
                                TestDataReader.GetData("DayOfBirth"),
                                TestDataReader.GetData("MonthOfBirth"),
                                TestDataReader.GetData("YearOfBirth"),
                                TestDataReader.GetData("Landline"),
                                TestDataReader.GetData("MobilePhone"),
                                TestDataReader.GetData("Email"),
                                TestDataReader.GetData("Country"));
        }

        public Passenger WithInvalidEmail()
        {
            return new Passenger(TestDataReader.GetData("FirstName"),
                                TestDataReader.GetData("FamilyName"),
                                TestDataReader.GetData("DayOfBirth"),
                                TestDataReader.GetData("MonthOfBirth"),
                                TestDataReader.GetData("YearOfBirth"),
                                TestDataReader.GetData("Landline"),
                                TestDataReader.GetData("MobilePhone"),
                                "boris.dedeikomail.r",
                                TestDataReader.GetData("Country"));
        }

        public Passenger WithInvalidYearOfBirth()
        {
            return new Passenger(TestDataReader.GetData("FirstName"),
                                TestDataReader.GetData("FamilyName"),
                                TestDataReader.GetData("DayOfBirth"),
                                TestDataReader.GetData("MonthOfBirth"),
                                "2014",
                                TestDataReader.GetData("Landline"),
                                TestDataReader.GetData("MobilePhone"),
                                TestDataReader.GetData("Email"),
                                TestDataReader.GetData("Country"));
        }
    }
}
