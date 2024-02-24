using Products.Domain.SeedWork;

namespace Products.Domain.Exceptions;

public class InvalidBarcodeControlSumException : DomainException
{
    public InvalidBarcodeControlSumException() : base("Неверная контрольная сумма") {}
}