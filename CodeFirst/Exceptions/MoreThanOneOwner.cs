namespace PrzykladowyKolok2.Exceptions;

public class MoreThanOneOwner : Exception
{
    public MoreThanOneOwner(string message) : base(message)
    {
        Message = message;
    }

    public override string Message { get; }
}