﻿namespace Packt.Shared;

// This file simulates an auto-generated class.
public partial class Person
{
    #region Properties: Methods to get and/or set data or state
    // A readonly property defined using C#1 to 5 syntax.
    public string Origin
    {
        get
        {
            return string.Format("{0} was born on {1}", arg0: Name, arg1: HomePlanet);
        }
    }

    // Two readonly properties defined using C#6 or later
    // Lambda expression body syntax.

    public string Greeting => $"{Name} says 'Hello!'";
    public int Age => System.DateTime.Today.Year - Born.Year;

    // A read-write property defined using C#3 auto-syntax.
    public string FavoriteIceCream { get; set; }

    // A private backing field to store the property value.
    private string _favoritePrimaryColor;

    // A public property to read and write to the field.
    public string? FavoritePrimaryColor
    {
        get
        {
            return _favoritePrimaryColor;
        }
        set
        {
            switch (value?.ToLower())
            {
                case "red":
                case "green":
                case "blue":
                    _favoritePrimaryColor = value;
                    break;
                default:
                    throw new ArgumentException(
                        message: $"{value} is not a primary color. " +
                        "Choose from: red, green, blue.");
            }
        }
    }
    #endregion

    private WondersOfTheAncientWorld _favoriteAncientWonder;

    public WondersOfTheAncientWorld FavoriteAncientWonder
    {
        get { return _favoriteAncientWonder; }
        set
        {
            string wonderName = value.ToString();

            if (wonderName.Contains(','))
            {
                throw new ArgumentException(
                    message: $"Favorite ancient wonder can only have a single enum value.", 
                    paramName: nameof(FavoriteAncientWonder));
            }
            if (!Enum.IsDefined(typeof(WondersOfTheAncientWorld), value))
            {
                throw new ArgumentException(
                    message: $"{value} is not a member of the WondersOfTheAncientWorld enum",
                    paramName: nameof(FavoriteAncientWonder));
            }
            _favoriteAncientWonder = value;
        }
    }

    #region Indexers: Properties that use array syntax to access them.
    public Person this[int index]
    {
        get { return Children[index]; } // Pass on to the List<T> indexer.
        set { Children[index] = value; }
    }
    #endregion

    // A read-only string indexer.
    public Person this[string name]
    {
        get { return Children.Find(p => p.Name == name); }
    }
}