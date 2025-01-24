namespace Packt.Shared;

public class  BankAccount
{
    public string? AccountName; // Instance Member . It could be null.
    public decimal Balance; // Instance Member. Default is zero.

    public static decimal InterestRate; // Shared Member. Defaults to zero.
}