using System.Runtime.InteropServices.Marshalling;

namespace DotNet8WebApi.MiniKpaySample.Features.TransactionHistory;

[Route("api/[controller]")]
[ApiController]
public class TransactionHistoryController : ControllerBase
{
    private readonly TransactionHistoryService _transactionHistoryService;

    public TransactionHistoryController(TransactionHistoryService transactionHistoryService)
    {
        _transactionHistoryService = transactionHistoryService;
    }

    [HttpPost]
    public async Task<IActionResult> TransactionHistory(TransactionHistoryRequestModel requestModel)
    {
        try
        {
            var result = requestModel.IsValid();
            if (!result.Success)
                return BadRequest(result);

            result = await _transactionHistoryService.TransactionHistory(requestModel);

            return Ok(result);
        }
        catch (Exception ex)
        {
            var result = Result<TransactionHistoryResponseModel>.FailureResult(ex);
            return StatusCode(500, result);
        }
    }

    [HttpPost("Datetime")]
    public async Task<IActionResult> TransactionDateHistory(TransactionHistoryDateRequestModel requestModel)
    {
        try
        {
            var result = requestModel.IsTransactionDateValid();
            if (!result.Success)
                return BadRequest(result);

            result = await _transactionHistoryService.TransactionDateHistory(requestModel);

            return Ok(result);

        }
        catch (Exception ex)
        {
            var result = Result<TransactionHistoryResponseModel>.FailureResult(ex);
            return StatusCode(500, result);
        }
    }
}
