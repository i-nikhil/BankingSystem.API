using BankingSystem.API.Interfaces;
using BankingSystem.API.Models;

namespace BankingSystem.API.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly Dictionary<Guid, Account> _accounts = new();

    public Account GetAccountById(Guid accountId)
    {
        _accounts.TryGetValue(accountId, out var account);
        return account;
    }

    public void CreateAccount(Account account)
    {
        _accounts[account.AccountId] = account;
    }

    public void UpdateAccount(Account account)
    {
        if (_accounts.ContainsKey(account.AccountId))
        {
            _accounts[account.AccountId] = account;
        }
    }
}
