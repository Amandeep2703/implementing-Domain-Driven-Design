using AirlineBooking.Api.Domain.Flights;
using AirlineBooking.Api.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace AirlineBooking.Api.Domain.Bookings
{
    public class Booking
    {

        public Guid Id
        {
            get;
            private set;
        }

        public Guid FlightId
        {
            get;
            private set;
        }

        //public List<Passenger> Passengers
        //{
        //    get;
        //    private set;
        //}
        private readonly List<Passenger> _passengers;
        public IReadOnlyCollection<Passenger> Passengers => _passengers;

        public Money TotalFare
        {
            get;
            private set;
        }

        public BookingStatus Status
        {
            get;
            private set;
        }

        public Seat? AssignedSeat
        {
            get;
            private set;
        }

        public Booking(Guid flightId, Money totalFare)
        {
            Id = Guid.NewGuid();
            FlightId = flightId;
            TotalFare = totalFare;
            Status = BookingStatus.Pending;
            _passengers = new List<Passenger>();
        }

        public void Confirm()
        {
            if (Status != BookingStatus.Pending)
            {
                throw new InvalidOperationException("only pending bookings can be confirmed;.");
            }

            if (_passengers.Count == 0)
                throw new InvalidOperationException("Cannot confirm a booking without passengers.");

            if (AssignedSeat == null)
                throw new InvalidOperationException("Cannot confirm booking without seat assignment.");

            Status = BookingStatus.Pending;
        }

        public void Cancel()
        {
            if (Status == BookingStatus.Cancelled)
            {
                return;
            }

            Status = BookingStatus.Cancelled;
        }

        public void AddPassenger(Passenger passenger)
        {
            if (Status != BookingStatus.Pending)
            {
                throw new InvalidOperationException("Passengers can only be added to pending bookings");
            }

            if (_passengers.Count >= 5)
            {
                throw new InvalidOperationException("A booking cannot exceed 5 passengers");
            }

            _passengers.Add(passenger);
        }

        public void AssignSeat(Seat seat)
        {
            if (Status != BookingStatus.Pending)
                throw new InvalidOperationException("Seat can only be assinged to pending bookinng");

            if (_passengers.Count == 0)
                throw new InvalidOperationException("Cannot assing seat without passenger");

            AssignedSeat = seat;
        }

    }

}