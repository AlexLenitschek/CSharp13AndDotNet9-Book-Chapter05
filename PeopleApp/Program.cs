using PackLibraryModern;
using Packt.Shared; // To use Person

ConfigureConsole(); // Sets the current culture to US English.

// Alternatives:
// ConfigureConsole(useComputerCulture: true); // Sets the current culture to the computer's culture.
// ConfigureConsole(culture: "fr-FR"); // Sets the current culture to French.

// Person Bob = new Person(); // C#1 or later.
// var Bob = new Person(); // C#3 or later.

Person bob = new(); // C#9 or later.
WriteLine(bob); // Implicit call to ToString().
// WriteLine(bob.ToString()); // Explicit call to ToString(). Does the same.

bob.Name = "Bob Smith";

bob.Born = new DateTimeOffset(
    year: 1965, month: 12, day: 22,
    hour: 16, minute: 28, second: 0, 
    offset: TimeSpan.FromHours(-5));

WriteLine(format: "{0} was born on {1:D}.", arg0: bob.Name, arg1: bob.Born); // Long date format. D


Person alice = new() 
{
    Name = "Alice Jones", 
    Born = new DateTimeOffset(1998, 3, 7, 15, 45, 0, TimeSpan.Zero) 
};

WriteLine(format: "{0} was born on {1:d}.", arg0: alice.Name, arg1: alice.Born); // Short date format. d


bob.FavoriteAncientWonder= WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

WriteLine(format: "{0}'s favorite wonder is {1}. Its integer is {2}.", 
    arg0: bob.Name, arg1: bob.FavoriteAncientWonder, arg2: (int)bob.FavoriteAncientWonder);

bob.BucketList = WondersOfTheAncientWorld.HangingGardensOfBabylon 
                | WondersOfTheAncientWorld.MausoleumAtHalicarnassus;

// bob.BucketList = (WondersOfTheAncientWorld)18; // 18 = 2 | 16

WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}.");

// Works with all versions of C#.
Person alfred = new Person();
alfred.Name = "Alfred";
bob.Children.Add(alfred);

// Works with C#3 and later.
bob.Children.Add(new Person { Name = "Bella" });

// Works with C#9 and later.
bob.Children.Add(new() { Name = "Zoe" });

WriteLine($"{bob.Name} has {bob.Children.Count} children:");

for (int childIndex = 0; childIndex < bob.Children.Count; childIndex++)
{
    WriteLine(bob.Children[childIndex].Name);
}

foreach(Person child in bob.Children)
{
    WriteLine("again {0}", child.Name);
}


BankAccount.InterestRate = 0.012M; // Store a shared value in static field.

BankAccount jonesAccount = new();
jonesAccount.AccountName = "Mrs. Jones";
jonesAccount.Balance = 2400;
WriteLine(format: "{0} earned {1:C} interest.",  
    // Remember, C is format code that tells .NET to use the current cultures currency format.
    arg0: jonesAccount.AccountName, 
    arg1: jonesAccount.Balance * BankAccount.InterestRate);

BankAccount gerrierAccount = new();
gerrierAccount.AccountName = "Ms. Gerrier";
gerrierAccount.Balance = 98;
WriteLine(format: "{0} earned {1:C} interest.",
    arg0: gerrierAccount.AccountName,
    arg1: gerrierAccount.Balance * BankAccount.InterestRate);

// Constant fields are accessible via the type.
WriteLine($"{bob.Name} is a {Person.Species}");

// Read-only fields are accessible via the variable.
WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

Book book = new()
{
    Isbn = "978-1803237800",
    Title = "C# 12 and .NET8 - Modern Cross Platform Development Fundamentals"
};

WriteLine("{0}: {1} written by {2} has {3:N0} pages.",
    book.Isbn,
    book.Title,
    book.Author,
    book.PageCount);