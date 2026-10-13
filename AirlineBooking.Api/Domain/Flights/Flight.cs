using System;

namespace AirlineBooking.Api.Domain.Flights
{
    public class Flight
    {
        public Guid Id
        {
            get;
            private set;
        }

        public Route Route { get; private set; }

        public DateTime DepartureTime { get; private set; }

        public DateTime ArrivalTime { get; private set; }

        public Flight(Route route, DateTime departureTime, DateTime arrivalTime)
        {
            Id = Guid.NewGuid();
            Route = route;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
        }
    }
}


