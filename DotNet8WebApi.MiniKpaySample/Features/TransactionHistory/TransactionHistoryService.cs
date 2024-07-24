namespace DotNet8WebApi.MiniKpaySample.Features.TransactionHistory;

public class TransactionHistoryService
{
    private readonly TransactionHistoryRepository _transactionHistoryRepository;

    public TransactionHistoryService(TransactionHistoryRepository transactionHistoryRepository)
    {
        _transactionHistoryRepository = transactionHistoryRepository;
    }

    public async Task<Result<TransactionHistoryResponseModel>> TransactionHistory(
        TransactionHistoryRequestModel requestModel)
    {
        bool isExist = await _transactionHistoryRepository.IsExistCustomerCode(requestModel.CustomerCode!);
        if (!isExist)
            return Result<TransactionHistoryResponseModel>.FailureResult("Customer doesn't exist.");

        var lst = await _transactionHistoryRepository.TransactionHistoryByCustomerCode(requestModel.CustomerCode!);
        var model = new TransactionHistoryResponseModel()
        {
            Data = lst
        };
        return Result<TransactionHistoryResponseModel>.SuccessResult(model);
    }

    public async Task<Result<TransactionHistoryResponseModel>> TransactionDateHistory(
        TransactionHistoryDateRequestModel requestModel)
    {
        bool isExit = await _transactionHistoryRepository.IsExistTransactionDate(requestModel.TransactionDate);
        if (!isExit)
            return Result<TransactionHistoryResponseModel>.FailureResult("History Date doesn't exist.");

        var lst = await _transactionHistoryRepository.TransactionHistoryByDatetime(requestModel.TransactionDate);
        var model = new TransactionHistoryResponseModel()
        {
            Data = lst
        };
        return Result<TransactionHistoryResponseModel>.SuccessResult(model);
    }
}