using UnitTestProject.Models;

namespace UnitTestProject.Service
{
    public class RouteCreator
    {
        public Route WithAllProperties()
        {
            return new Route(TestDataReader.GetData("Departure"),
                                TestDataReader.GetData("Arrival"),
                                TestDataReader.GetData("LeaveDate"));
        }

        public Route WithEmptyDeparture()
        {
            return new Route("", TestDataReader.GetData("Arrival"),
                            TestDataReader.GetData("LeaveDate"));
        }

        public Route WithEmptyLeaveData()
        {
            return new Route(TestDataReader.GetData("Departure"),
                                TestDataReader.GetData("Arrival"),
                                "");
        }
    }
}