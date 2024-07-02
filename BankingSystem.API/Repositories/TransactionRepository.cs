using BankingSystem.API.Interfaces;
using BankingSystem.API.Models;

namespace BankingSystem.API.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly List<Transaction> _transactions = new();

    public List<Transaction> GetTransactionsByAccountId(Guid accountId)
    {
        return _transactions.Where(t => t.AccountId == accountId).ToList();
    }

    public void CreateTransaction(Transaction transaction)
    {
        _transactions.Add(transaction);
    }
}
