namespace BankingSystem.API.Models;

public class Transaction
{
    public Guid TransactionId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public TransactionType TransactionType { get; set; }

    public Transaction()
    {
        TransactionId = Guid.NewGuid();
        TransactionDate = DateTime.UtcNow;
    }
}

public enum TransactionType
{
    Deposit,
    Withdrawal
}
