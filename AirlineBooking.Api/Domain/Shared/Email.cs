using System;

namespace AirlineBooking.Api.Domain.Shared
{
    public class Email
    {
        public string Value
        {
            get;
        }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
            {
                throw new ArgumentException("Invalid email format");
            }

            Value = value.ToLowerInvariant();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Email other)
            {
                return false;
            }

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
