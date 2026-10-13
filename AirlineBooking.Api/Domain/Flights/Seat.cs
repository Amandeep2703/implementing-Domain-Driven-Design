using System;

namespace AirlineBooking.Api.Domain.Flights
{
    public class Seat
    {
        public string Number
        {
            get;
        }

        public Seat(string number)
        {

            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Seat number is required");
            }
            
            Number = number;
            
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Seat other)
            {
                return false;
            }

            return Number == other.Number;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
