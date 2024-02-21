using Products.Domain.Exceptions;
using Products.Domain.SeedWork;

namespace Products.Domain.AggregateModels.Product;

public class Name : ValueObject<string>
{
    public Name(string value) : base(value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new EmptyValueException();
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}