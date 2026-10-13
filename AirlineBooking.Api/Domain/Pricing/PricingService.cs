using AirlineBooking.Api.Domain.Shared;
using Route = AirlineBooking.Api.Domain.Flights.Route;
using System;

namespace AirlineBooking.Api.Domain.Pricing
{
    public class PricingService
    {
        private const decimal BaseFarePerPassenger = 100m;

        public Money CalculateFare(Route route, int passengerCount)
        {
            if (passengerCount <= 0)
            {
                throw new InvalidOperationException("Passsenger count must be greater thatnn zero.");
            }

            decimal routeMultiplier = GetRoutMultiplier(route);

            decimal totalAmount = BaseFarePerPassenger * passengerCount * routeMultiplier;

            return new Money(totalAmount, "USD");
        }

        private decimal GetRoutMultiplier(Route route)
        {
            if (route.Origin == route.Destination)
            {
                throw new InvalidOperationException("Invalid route configuration");
            }

            return route.Origin.Substring(0, 1) == route.Destination.Substring(0,1) ? 1.2m : 1.5m;
        }

    }
}
