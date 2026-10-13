using AirlineBooking.Api.Domain.Bookings;
using System;
using System.Collections.Generic;

namespace AirlineBooking.Api.Infrastructure.Persistence
{
    public class InMemoryBookingRepository : IBookRepository
    {

        private readonly Dictionary<Guid, Booking> _store = new Dictionary<Guid, Booking>();

        public void Add(Booking booking)
        {
            if (_store.ContainsKey(booking.Id))
                throw new InvalidOperationException("Booking already exists");

            _store[booking.Id] = booking;
        }

        public Booking? GetById(Guid id)
        {
            _store.TryGetValue(id, out Booking? booking);
            return booking;
        }

        public void Remove(Booking booking)
        {
            if (!_store.ContainsKey(booking.Id))
                throw new InvalidOperationException("Booking does not exist");

            _store.Remove(booking.Id);
        }

        public void Update(Booking booking)
        {
            if (!_store.ContainsKey(booking.Id))
                throw new InvalidOperationException("Booking does not exist");

            _store[booking.Id] = booking;
        }

    }
}
