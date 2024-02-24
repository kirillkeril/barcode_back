using Products.Domain.SeedWork;

namespace Products.Domain.Exceptions;

public class WrongBarcodeFormatException : DomainException
{
    public WrongBarcodeFormatException() : base("Неверный формат штрих-кода") {}
}