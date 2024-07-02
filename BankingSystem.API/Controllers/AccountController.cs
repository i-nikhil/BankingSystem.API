using BankingSystem.API.DTOs;
using BankingSystem.API.Exceptions;
using BankingSystem.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("{accountId}")]
    public ActionResult<AccountDTO> GetAccountById(Guid accountId)
    {
        var account = _accountService.GetAccountById(accountId);
        return Ok(account);
    }

    [HttpPost]
    public ActionResult CreateAccount([FromBody] CreateAccountDTO createAccountDTO)
    {
        var accountId = _accountService.CreateAccount(createAccountDTO);
        return Created("", accountId);
    }

    [HttpPost("{accountId}/deposit")]
    public ActionResult Deposit(Guid accountId, [FromBody] decimal amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException("Deposit amount must be greater than zero.");

        _accountService.Deposit(accountId, amount);
        return Ok();
    }

    [HttpPost("{accountId}/withdraw")]
    public ActionResult Withdraw(Guid accountId, [FromBody] decimal amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException("Withdrawal amount must be greater than zero.");

        _accountService.Withdraw(accountId, amount);
        return Ok();
    }
}
