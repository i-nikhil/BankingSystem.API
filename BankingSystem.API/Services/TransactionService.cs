using BankingSystem.API.DTOs;
using BankingSystem.API.Exceptions;
using BankingSystem.API.Interfaces;

namespace BankingSystem.API.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IAccountRepository _accountRepository;

    public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository)
    {
        _transactionRepository = transactionRepository;
        _accountRepository = accountRepository;
    }

    public List<TransactionDTO> GetTransactionsByAccountId(Guid accountId)
    {
        if (_accountRepository.GetAccountById(accountId) is null)
            throw new AccountNotFoundException("Account not found");

        var transactions = _transactionRepository.GetTransactionsByAccountId(accountId);
        var transactionDTOs = new List<TransactionDTO>();

        foreach (var transaction in transactions)
        {
            transactionDTOs.Add(new TransactionDTO
            {
                TransactionId = transaction.TransactionId,
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate,
                TransactionType = transaction.TransactionType.ToString()
            });
        }

        return transactionDTOs;
    }
}
