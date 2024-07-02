using BankingSystem.API.DTOs;
using BankingSystem.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet("{accountId}")]
    public ActionResult<List<TransactionDTO>> GetTransactionsByAccountId(Guid accountId)
    {
        var transactions = _transactionService.GetTransactionsByAccountId(accountId);
        return Ok(transactions);
    }
}
