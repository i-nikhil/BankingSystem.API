namespace BankingSystem.API.DTOs;

public class TransactionDTO
{
    public Guid TransactionId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public string TransactionType { get; set; }
}
