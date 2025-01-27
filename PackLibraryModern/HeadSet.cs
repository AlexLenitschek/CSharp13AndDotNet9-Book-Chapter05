namespace Packt.Shared;

//public class Headset(string manufacturer, string productName); // 
// A difference between class and record type with primary constructor is that it's parameters don't
// become public properties automatically.
// Neither ProductName nor Manufacturer are accessible outside the class.

public class Headset(string manufacturer, string productName)
{
    public string Manufacturer { get; set; } = manufacturer;
    public string ProductName { get; set; } = productName;

    // Default parameterless constructor calls the primary constructor.
    public Headset() : this("Microsoft", "HoloLens") { }
    // this() calls the constructor of the base class.
}
