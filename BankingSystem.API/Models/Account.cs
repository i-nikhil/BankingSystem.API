namespace BankingSystem.API.Models;

public class Account
{
    public Guid AccountId { get; set; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }

    public Account()
    {
        AccountId = Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        Balance = 0.0M;
    }
}
