namespace DotNet8WebApi.MiniKpaySample.Features.Transfer;

[Route("api/[controller]")]
[ApiController]
public class TransferController : ControllerBase
{
    private readonly TransferService _transferService;

    public TransferController(TransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpPost]
    public async Task<IActionResult> Transfer(TransferRequestModel requestModel)
    {
        try
        {
            var result = requestModel.IsValid();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            result = await _transferService.Transfer(requestModel);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var model = Result<TransferResponseModel>.FailureResult(ex.ToString());
            return StatusCode(500, model);
        }
    }
}