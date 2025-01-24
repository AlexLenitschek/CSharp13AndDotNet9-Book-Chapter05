namespace Packt.Shared;


public class Person : object
{
    #region Fields: Data or State for this person.
    public string? Name; // ? means it can be null.
    public DateTimeOffset Born;
    public List<Person> Children = new();
    public WondersOfTheAncientWorld FavoriteAncientWonder;
    public WondersOfTheAncientWorld BucketList;
    public const string Species = "Homo Sapiens"; // Constant Fields: Values that are fixed at compilation.
    public readonly string HomePlanet = "Earth";  // Read-only fields are accessible via the variable.
    #endregion
}