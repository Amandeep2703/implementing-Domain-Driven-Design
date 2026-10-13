using AirlineBooking.Api.Domain.Bookings;
using AirlineBooking.Api.Domain.Shared;
using System;

namespace AirlineBooking.Api.Application.Bookings
{
    public class BookingApplicationService
    {
        private readonly IBookRepository _repository;

        public BookingApplicationService(IBookRepository repository)
        {
            _repository = repository;   
        }

        public Guid CreateBooking(Guid flightId, decimal amount, string currency)
        {
             Money? money = new Money(amount, currency);

            Booking? booking = new Booking(flightId, money);

            _repository.Add(booking);

            return booking.Id;
        }

        public void AddPassenger(Guid bookingId, string fullName, string passportNumber)
        {
            Booking? booking = _repository.GetById(bookingId);

            if (booking == null)
            {
                throw new InvalidOperationException("Booking not found.");
            }

            Passenger? passenger = new Passenger(fullName, passportNumber);

            booking.AddPassenger(passenger);

            _repository.Update(booking);
        }

        public void ConfirmBooking(Guid bookingId)
        {
            Booking? booking = _repository.GetById(bookingId);

            if (booking == null)
            {
                throw new InvalidOperationException("Booking not found.");
            }

            booking.Confirm();
            _repository.Update(booking);
        }
    }
}
