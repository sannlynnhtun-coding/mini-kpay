namespace DotNet8WebApi.MiniKpaySample.Models.Transfer;

public class TransferRequestModel
{
    public string FromMobileNo { get; set; }
    public string ToMobileNo { get; set; }
    public decimal Amount { get; set; }

    public Result<TransferResponseModel> IsValid()
    {
        try
        {
            if (string.IsNullOrEmpty(FromMobileNo))
                return Result<TransferResponseModel>.FailureResult("Invalid From Mobile No.");

            if (string.IsNullOrEmpty(ToMobileNo))
                return Result<TransferResponseModel>.FailureResult("Invalid To Mobile No.");

            if (Amount <= 0)
                return Result<TransferResponseModel>.FailureResult("Invalid Amount. Amount must be greater than zero.");

            return Result<TransferResponseModel>.SuccessResult();
        }
        catch (Exception ex)
        {
            return Result<TransferResponseModel>.FailureResult(ex.ToString());
        }
    }
}