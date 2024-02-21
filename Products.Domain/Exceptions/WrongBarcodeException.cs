namespace Products.Domain.Exceptions;

public class WrongBarcodeFormatException : Exception
{
    public WrongBarcodeFormatException() : base("Неверный формат штрих-кода") {}
}