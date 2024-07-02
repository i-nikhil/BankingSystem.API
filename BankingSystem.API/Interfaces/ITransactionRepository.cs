using BankingSystem.API.Models;

namespace BankingSystem.API.Interfaces;

public interface ITransactionRepository
{
    List<Transaction> GetTransactionsByAccountId(Guid accountId);
    void CreateTransaction(Transaction transaction);
}
