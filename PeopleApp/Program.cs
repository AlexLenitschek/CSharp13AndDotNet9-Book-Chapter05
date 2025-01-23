using Packt.Shared; // To use Person

ConfigureConsole(); // Sets the current culture to US English.

// Alternatives:
// ConfigureConsole(useComputerCulture: true); // Sets the current culture to the computer's culture.
// ConfigureConsole(culture: "fr-FR"); // Sets the current culture to French.

// Person Bob = new Person(); // C#1 or later.
// var Bob = new Person(); // C#3 or later.

Person bob = new(); // C#9 or later.
WriteLine(bob); // Implicit call to ToString().

bob.Name = "Bob Smith";

bob.Born = new DateTimeOffset(
    year: 1965,
    month: 12,
    day: 22,
    hour: 16,
    minute: 28,
    second: 0, 
    offset: TimeSpan.FromHours(-5));

WriteLine(format: "{0} was born on {1:D}.", arg0: bob.Name, arg1: bob.Born);


// WriteLine(bob.ToString()); // Explicit call to ToString(). Does the same.