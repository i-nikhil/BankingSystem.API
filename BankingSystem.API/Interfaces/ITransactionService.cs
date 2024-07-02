using BankingSystem.API.DTOs;

namespace BankingSystem.API.Interfaces;

public interface ITransactionService
{
    List<TransactionDTO> GetTransactionsByAccountId(Guid accountId);
}
