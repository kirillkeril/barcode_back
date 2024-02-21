namespace Products.Domain.SeedWork;

public abstract class ValueObject<T>
{
    public T Value { get; }

    public ValueObject(T value)
    {
        this.Value = value;
    }
    
    protected static bool EqualOperator(ValueObject<T> left, ValueObject<T> right)
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
        {
            return false;
        }
        return ReferenceEquals(left, right) || left.Equals(right);
    }

    protected static bool NotEqualOperator(ValueObject<T> left, ValueObject<T> right)
    {
        return !(EqualOperator(left, right));
    }

    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj != null || obj?.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<T>)obj;

        return this.GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x.GetHashCode())
            .Aggregate((x, y) => x ^ y);
    }

    public static bool operator ==(ValueObject<T> left, ValueObject<T> right)
    {
        return EqualOperator(left, right);
    }

    public static bool operator !=(ValueObject<T> left, ValueObject<T> right)
    {
        return !(left == right);
    }
}