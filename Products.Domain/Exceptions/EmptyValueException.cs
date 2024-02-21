namespace Products.Domain.Exceptions;

public class EmptyValueException : Exception
{
    public EmptyValueException() : base("Имя не может быть пустым") { }
}