using System.Collections.Generic;
using System;

namespace AirlineBooking.Api.Domain.Flights
{
    public class SeatAllocationService
    {
        public Seat AllocateSeat(List<Seat> availableSeats, int passsengerIndex)
        {
            if (availableSeats == null || availableSeats.Count == 0)
            {
                throw new InvalidOperationException("No seats available");
            }

            if (passsengerIndex < 0)
            {
                throw new InvalidOperationException("Invalid passenger index");
            }

            if (passsengerIndex >= availableSeats.Count)
            {
                throw new InvalidOperationException("Not enough seats available for passengers");
            }

            return availableSeats[passsengerIndex];
        }
    }
}
