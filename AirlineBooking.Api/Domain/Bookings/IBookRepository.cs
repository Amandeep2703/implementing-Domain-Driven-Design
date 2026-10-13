using System;

namespace AirlineBooking.Api.Domain.Bookings
{
    public interface IBookRepository
    {
        Booking?  GetById(Guid id);

        void Add(Booking booking);

        void Update(Booking booking);

        void Remove(Booking booking);
    }
}
