namespace Framework.Models
{
    public class Passenger
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string DayOfBirth { get; set; }
        public string MonthOfBirth { get; set; }
        public string YearOfBirth { get; set; }
        public string Landline { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public Passenger(string firstName, string familyName, string dayOfBirth,
                            string monthOfBirth, string yearOfBirth, string landline,
                            string mobilePhone, string email, string country)
        {
            FirstName = firstName;
            FamilyName = familyName;
            DayOfBirth = dayOfBirth;
            MonthOfBirth = monthOfBirth;
            YearOfBirth = yearOfBirth;
            Landline = landline;
            MobilePhone = mobilePhone;
            Email = email;
            Country = country;
        }
    }
}
