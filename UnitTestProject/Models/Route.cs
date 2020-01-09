namespace UnitTestProject.Models
{
    public class Route
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string LeaveDate { get; set; }

        public Route(string departure, string arrival, string leaveDate)
        {
            Departure = departure;
            Arrival = arrival;
            LeaveDate = leaveDate;
        }

        public override string ToString()
        {
            return "Route  {" +
                    $"Departure = {Departure}, " +
                    $"Arrival = {Arrival}" +
                    $"LeaveDate = {LeaveDate}" +
                    "}";
        }

        public override bool Equals(object obj)
        {
            Route route = obj as Route;

            if (route == null) return false;

            return Equals(this.Departure, route.Departure) &&
                    Equals(this.Arrival, route.Arrival) &&
                    Equals(this.LeaveDate, route.LeaveDate);
        }

        public override int GetHashCode()
        {
            return Departure.GetHashCode() +
                    Arrival.GetHashCode() +
                    LeaveDate.GetHashCode();
        }
    }
}
