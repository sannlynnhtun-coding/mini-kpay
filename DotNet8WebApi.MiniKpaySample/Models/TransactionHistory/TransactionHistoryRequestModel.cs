namespace DotNet8WebApi.MiniKpaySample.Models.TransactionHistory;

public class TransactionHistoryRequestModel
{
    public string? CustomerCode { get; set; }

    public Result<TransactionHistoryResponseModel> IsValid()
    {
        try
        {
            if (string.IsNullOrEmpty(CustomerCode))
                return Result<TransactionHistoryResponseModel>.FailureResult("Invalid Customer Code.");
            return Result<TransactionHistoryResponseModel>.SuccessResult();
        }
        catch (Exception ex)
        {
            return Result<TransactionHistoryResponseModel>.FailureResult(ex.ToString());
        }
    }
}
