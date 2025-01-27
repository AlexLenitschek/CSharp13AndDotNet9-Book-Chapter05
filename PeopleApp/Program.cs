using PackLibraryModern;
using Packt.Shared; // To use Person
using Fruit = (string Name, int Number); // Aliasing a tuple type.

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


bob.FavoriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;

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

Person blankPerson = new();

WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: blankPerson.Name,
    arg1: blankPerson.HomePlanet,
    arg2: blankPerson.Instantiated);

Person gunny = new(InitialName: "Gunny", homePlanet: "Mars");

WriteLine(format: "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
    arg0: gunny.Name,
    arg1: gunny.HomePlanet,
    arg2: gunny.Instantiated);



/*
// Instantiate a book using object initializer syntax.
Book book = new Book
{
    Isbn = "978-1803237800",
    Title = "C# 12 and .NET8 - Modern Cross Platform Development Fundamentals"
};
*/
Book book1 = new(
    isbn: "978-1803237800", 
    title: "C# 12 and .NET8 - Modern Cross Platform Development Fundamentals")
{
    Author = "Mark J. Price", PageCount = 821 
};

WriteLine("{0}: {1} written by {2} has {3:N0} pages.",
    book1.Isbn,
    book1.Title,
    book1.Author,
    book1.PageCount);

bob.WriteToConsole();
WriteLine(bob.GetOrigin());

WriteLine(bob.SayHello());
WriteLine(bob.SayHello("Emily"));

WriteLine(bob.OptionalParameters(3));
WriteLine(bob.OptionalParameters(3,"Jump!", 98.5));
WriteLine(bob.OptionalParameters(3, number: 52.7, command: "Hide!"));
WriteLine(bob.OptionalParameters(3, "Poke!", active: false));
WriteLine();

int a = 10;
int b = 20;
int c = 30;
int d = 40;

WriteLine($"Before: a = {a}, b = {b}, c = {c}, d = {d}");

bob.PassingParameters(a, in b, ref c, out d);

WriteLine($"After: a = {a}, b = {b}, c = {c}, d = {d}");
WriteLine();

int e = 50;
int f = 60;
int g = 70;
WriteLine($"Before: e = {e}, f = {f}, g = {g}, h doesnt exist yet!");

// Simplified C#7 or later syntax for the out parameter.
bob.PassingParameters(e, in f, ref g, out int h);
WriteLine($"After: e = {e}, f = {f}, g = {g}, h = {h}");
WriteLine();

bob.ParamsParameters("Sum using commas", 3, 6, 1, 2);
bob.ParamsParameters("Sum using collection expression", [3, 6, 1, 2]);
bob.ParamsParameters("Sum using explicit array", new int[] { 3, 6, 1, 2 });
bob.ParamsParameters("Sum (empty)");
WriteLine();

(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} of them.");

// var is used here to shorten the expression.
// (string Name, int Number) fruitNamed = bob.GetNamedFruit();
var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");

var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");

var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");
WriteLine();


// Without an aliased tuple type.
var fruitNamed2 = bob.GetNamedFruit();
WriteLine($"{fruitNamed2.Name}, {fruitNamed2.Number} of them.");

// With an aliased tuple type.
Fruit fruitNamed3 = bob.GetNamedFruit();
WriteLine($"{fruitNamed3.Name}, {fruitNamed3.Number} of them.");

// NOTE THE SAME RESULTS ARE PRINTED IN BOTH CASES.
WriteLine();


// Store return value in a tuple variable with two named fields.
(string Name, int Number) fruitNamed4 = bob.GetNamedFruit();

// You can then access the named fields.
WriteLine($"{fruitNamed4.Name}, {fruitNamed4.Number} of them.");

// Deconstruct the return value into two separate variables.
(string fruitName, int fruitNumber) = bob.GetNamedFruit();

// You can then access the seperate variables.
WriteLine($"Deconstructed tuple: {fruitName}, {fruitNumber}");
WriteLine();


var (name1, dob1) = bob; // Implicitly calls the Deconstruct method.
WriteLine($"Deconstructed Person: {name1}, {dob1}");

var (name2, dob2, fav2) = bob; // Implicitly calls the Deconstruct method.
WriteLine($"Deconstructed Person: {name2}, {dob2}, {fav2}");
// You do not explicitly call the Deconstruct method.
WriteLine();

#region Testing the local function.
// Change to -1 to make the exception handling code execute.
int number = 5;

try
{
    WriteLine($"{number}! is {Person.Factorial(number)}");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says: {ex.Message} number was {number}");
}
WriteLine();

// Testing the partial functions getter.
Person sam = new()
{
    Name = "Sam",
    Born = new(1969, 6, 25, 0, 0, 0, TimeSpan.Zero)
};

WriteLine(sam.Origin);
WriteLine(sam.Greeting);
WriteLine(sam.Age);
WriteLine();
#endregion

#region Using getter and setter of Person in PersonAutoGen.cs

sam.FavoriteIceCream = "Chocolate Fudge";
WriteLine($"Sam's favorite ice-cream flavor is {sam.FavoriteIceCream}");

string color = "Red";
try
{
    sam.FavoritePrimaryColor = color;
    WriteLine($"Sam's favorite primary color is {sam.FavoritePrimaryColor}");
}
catch (Exception ex)
{
    WriteLine("Tried to set {0} to '{1}': {2}", nameof(sam.FavoritePrimaryColor), color, ex.Message);
}
#endregion

#region Indexers: 
sam.Children.Add(new() 
{ 
    Name = "Charlie", 
    Born = new(2010, 3, 18, 0, 0, 0, TimeSpan.Zero) 
});

sam.Children.Add(new()
{
    Name = "Ella",
    Born = new(2020, 12, 24, 0, 0, 0, TimeSpan.Zero)
});

// Get using Childrens list. - Vanilla way.
WriteLine("Sam's first child is {0}", sam.Children[0].Name);
WriteLine("Sam's second child is {0}", sam.Children[1].Name);

// Get using the int indexer.
WriteLine("Sam's first child is {0}", sam[0].Name);
WriteLine("Sam's second child is {0}", sam[1].Name);

// Get using the string indexer.
WriteLine($"Sam's child named Ella is {sam["Ella"].Age} years old.");
WriteLine();
#endregion

#region Pattern matching flight passengers

// An array containing a mix of passenger types.
Passenger[] passengers = {
  new FirstClassPassenger { AirMiles = 1_419, Name = "Suman" },
  new FirstClassPassenger { AirMiles = 16_562, Name = "Lucy" },
  new BusinessClassPassenger { Name = "Janice" },
  new CoachClassPassenger { CarryOnKG = 25.7, Name = "Dave" },
  new CoachClassPassenger { CarryOnKG = 0, Name = "Amit" },
};

foreach (Passenger passenger in passengers)
{
    decimal flightCost = passenger switch
    {
        /*C# 8 syntax
        FirstClassPassenger p when p.AirMiles > 35_000 => 1_500M,
        FirstClassPassenger p when p.AirMiles > 15_000 => 1_750M,
        FirstClassPassenger _                          => 2_000M,*/

        // C# 9 or later syntax
        FirstClassPassenger p => p.AirMiles switch
        {
            > 35_000 => 1_500M,
            > 15_000 => 1_750M,
            _ => 2_000M
        },

        // Or alternatively use the relational pattern in combination
        // with the property pattern to avoid the nested switch expression:
        // FirstClassPassenger { AirMiles: > 35_000 } => 1_500M,
        // FirstClassPassenger { AirMiles: > 15_000 } => 1_750M,
        // FirstClassPassenger                        => 2_000M,

        BusinessClassPassenger _ => 1_000M,
        CoachClassPassenger p when p.CarryOnKG < 10.0 => 500M,
        CoachClassPassenger _ => 650M,
        _ => 800M
    };
    WriteLine($"Flight costs {flightCost:C} for {passenger}");
}
WriteLine();
#endregion

#region Init-only properties
ImmutablePerson jeff = new()
{
    FirstName = "Jeff",
    LastName = "Winger"
};
//jeff.FirstName = "Geoff"; // Because the set is actually init, this leads to the following error:
// Error CS8852: Init-only property or indexer 'ImmutablePerson.FirstName'
// can only be assigned in an object initializer, or on 'this' or 'base' in
// an instance constructor or an 'init' accessor.
#endregion

#region Record Types
ImmutableVehicle car = new()
{
    Brand = "Mazda MX-5 RF",
    Color = "Soul Red Crystal metallic",
    Wheels = 4
};

ImmutableVehicle repaintedCar = car with { Color = "Polymetal Grey" };

WriteLine($"Original car color was {car.Color}");
WriteLine($"Repainted car color is {repaintedCar.Color}");

WriteLine();
#endregion

#region Equality of Record types
AnimalClass ac1 = new() { Name = "Rex"};
AnimalClass ac2 = new() { Name = "Rex" };

WriteLine($"ac1 == ac2: {ac1 == ac2}"); // False, because class is used even though the property values equal.
// Class instances are only equal if they are literally the same object. True when their memory addresses are equal.
AnimalRecord ar1 = new() { Name = "Rex" };
AnimalRecord ar2 = new() { Name = "Rex" };

WriteLine($"ar1 == ar2: {ar1 == ar2}"); // True, because record is used this time.

WriteLine();
#endregion

#region Equality of other types.
int number1 = 3;
int number2 = 3;
WriteLine($"number1: {number1}, number2: {number2}");
WriteLine($"number1 == number2: {number1 == number2}");
WriteLine();
// Because equality of two reference type variables is tested by .NET.
// The memory addresses of these are equal.

Person p1 = new() { Name = "Kevin" };
Person p2 = new() { Name = "Kevin" };
WriteLine($"p1: {p1}, p2: {p2}");
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1 == p2: {p1 == p2}");
WriteLine();
// This is because they are not the same object. If both variables would point at the same object in the heap,
// then they would be equal.

Person p3 = p1;
WriteLine($"p1: {p1}, p3: {p3}");
WriteLine($"p3.Name: {p3.Name}");
WriteLine($"p1 == p3: {p1 == p3}");
WriteLine();
// This is because p3 is a reference type of p1 and therefore equal.

// String is the only class reference type implemented to act like a value type for equality.
WriteLine($"p1.Name: {p1.Name}, p2.Name: {p2.Name}");
WriteLine($"p1.Name == p2.Name: {p1.Name == p2.Name}");
WriteLine();
#endregion

#region Positional data members in records.
ImmutableAnimal oscar = new("Oscar", "Labrador");
var (who, what) = oscar; // Calls the Deconstruct method.
WriteLine($"{who} is a {what}");
WriteLine();
#endregion

#region Defining a primary constructor for a class.
Headset vp = new("Apple", "Vision Pro");
WriteLine($"The {vp.ProductName} is made by {vp.Manufacturer}");
Headset holo = new();
WriteLine($"{holo.ProductName} is made by {holo.Manufacturer}");
Headset mq = new() { Manufacturer = "Meta", ProductName = "Quest 3" };
WriteLine($"{mq.ProductName} is made by {mq.Manufacturer}");
WriteLine();
#endregion


#region Exercise 5.2 - Practice access modifiers.
Car fiat = new() { Wheels = 4, IsEV = true};
fiat.Start();
#endregion