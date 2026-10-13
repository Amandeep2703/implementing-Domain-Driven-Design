namespace AirlineBooking.Api.Domain.Bookings;

public class Passenger
{
    public string FullName
    {
        get; private set;
    }

    public string PassengerNumber
    {
        get;
        private set;
    }

    public Passenger(string fullName, string passportNumber)
    {
        FullName = fullName;
        PassengerNumber = passportNumber;
    }
}
