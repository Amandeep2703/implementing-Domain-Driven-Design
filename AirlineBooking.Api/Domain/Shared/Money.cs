using System;

namespace AirlineBooking.Api.Domain.Shared
{
    public class Money
    {
        public decimal Amount
        {
            get;
        }

        public string Currency
        {
            get;
        }

        public Money(decimal amount, string currency)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Mony cannot be negative");
            }

            Amount = amount;
            Currency = currency;

        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
            {
                throw new InvalidOperationException("Connnot add different currencies");
            }

            return new Money(Amount + other.Amount, Currency);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Money other)
            {
                return false;
            }

            return Amount == other.Amount && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount, Currency);
        }

        public static Money operator +(Money left, Money right)
        {
            return new Money(left.Amount + right.Amount, right.Currency);
        }

    }

}