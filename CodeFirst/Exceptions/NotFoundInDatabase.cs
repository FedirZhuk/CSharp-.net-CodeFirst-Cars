namespace PrzykladowyKolok2.Exceptions;

public class NotFoundInDatabase : Exception
{
    public NotFoundInDatabase(string message) : base(message)
    {
        Message = message;
    }

    public override string Message { get; }
}