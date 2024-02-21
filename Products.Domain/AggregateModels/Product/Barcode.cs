using Products.Domain.Exceptions;
using Products.Domain.SeedWork;

namespace Products.Domain.AggregateModels.Product;

public class Barcode : ValueObject<string>
{
    public Barcode(string value) : base(value)
    {
        if (value.Length < 8 || value.Length > 13)
            throw new WrongBarcodeFormatException();
        if (!CheckBarcodeValidity(value))
            throw new InvalidBarcodeControlSumException();
    }

    private bool CheckBarcodeValidity(string barcode)
    {
        barcode = barcode.PadLeft(14, '0');
        var sum = barcode.Select((c,i) => (c - '0')  * (i % 2 == 0 ? 3 : 1)).Sum();
        return (sum % 10) == 0;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}