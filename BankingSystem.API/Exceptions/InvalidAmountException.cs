namespace BankingSystem.API.Exceptions;

public class InvalidAmountException : Exception
{
    public InvalidAmountException(string message) : base(message)
    {
    }
}
