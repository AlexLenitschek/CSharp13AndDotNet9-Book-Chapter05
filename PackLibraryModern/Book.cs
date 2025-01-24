namespace PackLibraryModern
{
    public class Book
    {
        // Needs .NET 7 or later as well as C# 11 or later.
        public required string? Isbn;
        public required string? Title;

        // Works with any version of .NET
        public string? Author;
        public int PageCount;
    }
}
