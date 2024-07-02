using BankingSystem.API.Models;

namespace BankingSystem.API.Interfaces;

public interface IAccountRepository
{
    Account GetAccountById(Guid accountId);
    void CreateAccount(Account account);
    void UpdateAccount(Account account);
}
