namespace Packt.Shared;

public class Person : object
{
    #region Fields: Data or State for this person.
    public string? Name; // ? means it can be null.
    public DateTimeOffset Born;

    #endregion
}