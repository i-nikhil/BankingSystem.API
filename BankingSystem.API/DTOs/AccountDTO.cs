namespace BankingSystem.API.DTOs;

public class AccountDTO
{
    public Guid AccountId { get; set; }
    public string AccountHolderName { get; set; }
    public decimal Balance { get; set; }
    public DateTime CreatedDate { get; set; }
}
