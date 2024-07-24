namespace DotNet8WebApi.MiniKpaySample.Models.TransactionHistory;

public class TransactionHistoryDateRequestModel
{
    public string TransactionDate { get; set; }

    public Result<TransactionHistoryResponseModel> IsTransactionDateValid()
    {
        try
        {
            if (string.IsNullOrEmpty(TransactionDate))
                return Result<TransactionHistoryResponseModel>.FailureResult("Invalid DateTime.");
            return Result<TransactionHistoryResponseModel>.SuccessResult();
        }
        catch (Exception ex)
        {
            return Result<TransactionHistoryResponseModel>.FailureResult(ex.ToString());
        }
    }
}