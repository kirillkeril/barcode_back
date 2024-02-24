using Products.Domain.SeedWork;

namespace Products.Domain.Exceptions;

public class EmptyValueException : DomainException
{
    public EmptyValueException() : base("Имя не может быть пустым") { }
}