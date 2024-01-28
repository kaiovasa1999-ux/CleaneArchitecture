namespace Domain.Entities;
public class Money : IEquatable<Money>
{
    public decimal Amount { get; }
    public string Currency { get; }

    public Money(decimal amount, string currency)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative.", nameof(amount));
        }

        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be null or empty.", nameof(currency));
        }

        Amount = amount;
        Currency = currency.ToUpper(); // Convert currency to uppercase for consistency
    }

    // Override Equals and GetHashCode for value equality
    public override bool Equals(object obj)
    {
        return Equals(obj as Money);
    }

    public bool Equals(Money other)
    {
        return other != null &&
               Amount == other.Amount &&
               Currency == other.Currency;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Amount, Currency);
    }

    // Optional: Override ToString for better representation
    public override string ToString()
    {
        return $"{Amount} {Currency}";
    }
}


