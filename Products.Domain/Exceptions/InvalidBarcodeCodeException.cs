namespace Products.Domain.Exceptions;

public class InvalidBarcodeControlSumException : Exception
{
    public InvalidBarcodeControlSumException() : base("Неверная контрольная сумма") {}
}