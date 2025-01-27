namespace Packt.Shared;

/*class Car
{
    int Wheels { get; set; }
    public bool IsEV { get; set; }
    internal void Start()
    { Console.WriteLine("Car starting..."); }
}*/

public class Car
{
    public int Wheels { get; set; }
    public bool IsEV { get; set; }
    public void Start()
    { Console.WriteLine("Car starting..."); }
}

// RESULTS: 
// The original Car class was not initialized with any access modifiers and was therefore internal.
// Meaning it was only within the same assembly accessible.
// Wheels accessibility was also not initialized and was therefore private.
// Start() was defined as internal making it also inaccessible in program.cs.


/* Access Modifiers - (Ranked by accessability [ASC Order])
private:
Accessible only within the same class.

private protected
Accessible within the same class and derived classes in the same assembly.

file
Accessible only within the same source file.

protected
Accessible within the same class and derived (child) classes.

internal
Accessible within the same assembly (project).

protected internal
Accessible within the same assembly or derived classes in any assembly.

public
Accessible from anywhere.
 */

/* Difference between static, const, and readonly keywords applied to type members:
static: Belongs to the type, not instances; shared and mutable unless combined with readonly.
const: Compile-time constant; immutable; implicitly static.
readonly: Runtime constant; can be set at declaration or in the constructor; immutable after assignment.
 */

/*
 public List<Person> Children = new();: Declares a field with a single, 
persistent instance of List<Person>, which can be modified throughout the object's lifetime.

public List<Person> Children => new();: Declares a property that creates and returns a new 
instance of List<Person> each time it is accessed.

Key difference: The field persists and is modifiable, while the property creates a new instance 
on each access, often used for immutability or when a fresh list is needed each time.
 */