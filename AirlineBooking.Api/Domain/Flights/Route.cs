using System;

namespace AirlineBooking.Api.Domain.Flights
{
    public class Route
    {
        public string Origin
        {
            get;
        }

        public string Destination
        {
            get;
        }

        public Route(string origin, string destination)
        {
            if (string.IsNullOrWhiteSpace(origin) || string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentException("Route must haave valid origin and destination");
            }

            Origin = origin;
            Destination = destination;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Route other)
            {
                return false;
            }

            return Origin == other.Origin && Destination == other.Destination;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Origin, Destination);
        }
    }
}
