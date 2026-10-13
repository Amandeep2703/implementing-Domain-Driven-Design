using AirlineBooking.Api.Domain.Bookings;
using AirlineBooking.Api.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineBooking.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IBookRepository, InMemoryBookingRepository>();

            return services;
        }
    }
}
