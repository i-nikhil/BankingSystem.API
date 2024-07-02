using BankingSystem.API.DTOs;

namespace BankingSystem.API.Interfaces;

public interface IAccountService
{
    AccountDTO GetAccountById(Guid accountId);
    Guid CreateAccount(CreateAccountDTO createAccountDTO);
    void Deposit(Guid accountId, decimal amount);
    void Withdraw(Guid accountId, decimal amount);
}
