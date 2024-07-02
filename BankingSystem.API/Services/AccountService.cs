using BankingSystem.API.DTOs;
using BankingSystem.API.Exceptions;
using BankingSystem.API.Interfaces;
using BankingSystem.API.Models;

namespace BankingSystem.API.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public AccountDTO GetAccountById(Guid accountId)
    {
        var account = _accountRepository.GetAccountById(accountId);
        if (account == null)
            throw new AccountNotFoundException("Account not found");

        return new AccountDTO
        {
            AccountId = account.AccountId,
            AccountHolderName = account.AccountHolderName,
            Balance = account.Balance,
            CreatedDate = account.CreatedDate
        };
    }

    public Guid CreateAccount(CreateAccountDTO createAccountDTO)
    {
        var account = new Account
        {
            AccountHolderName = createAccountDTO.AccountHolderName
        };
        _accountRepository.CreateAccount(account);

        return account.AccountId;
    }

    public void Deposit(Guid accountId, decimal amount)
    {
        var account = _accountRepository.GetAccountById(accountId);
        if (account == null)
            throw new AccountNotFoundException("Account not found");

        account.Balance += amount;
        _accountRepository.UpdateAccount(account);

        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            TransactionType = TransactionType.Deposit
        };
        _transactionRepository.CreateTransaction(transaction);
    }

    public void Withdraw(Guid accountId, decimal amount)
    {
        var account = _accountRepository.GetAccountById(accountId);
        if (account == null)
            throw new AccountNotFoundException("Account not found");

        if (account.Balance < amount)
            throw new InsufficientFundsException("Insufficient funds");

        account.Balance -= amount;
        _accountRepository.UpdateAccount(account);

        var transaction = new Transaction
        {
            AccountId = accountId,
            Amount = amount,
            TransactionType = TransactionType.Withdrawal
        };
        _transactionRepository.CreateTransaction(transaction);
    }
}
