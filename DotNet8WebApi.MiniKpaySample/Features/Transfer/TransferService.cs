namespace DotNet8WebApi.MiniKpaySample.Features.Transfer;

public class TransferService
{
    private readonly TransferRepository _transferRepository;

    public TransferService(TransferRepository transferRepository)
    {
        _transferRepository = transferRepository;
    }

    public async Task<Result<TransferResponseModel>> Transfer(TransferRequestModel requestModel)
    {
        var result = await _transferRepository.ValidateMobileNumber(requestModel.FromMobileNo);
        if (!result.Success)
            return result;

        result = await _transferRepository.ValidateMobileNumber(requestModel.ToMobileNo);
        if (!result.Success)
            return result;

        result = await _transferRepository.HandleInsufficientBalance(requestModel.FromMobileNo, requestModel.Amount);
        if (!result.Success)
            return result;

        await _transferRepository.DecreaseAmount(requestModel.FromMobileNo, requestModel.Amount);
        await _transferRepository.IncreaseAmount(requestModel.ToMobileNo, requestModel.Amount);
        await _transferRepository.CreateTransaction(requestModel);

        return Result<TransferResponseModel>.SuccessResult();
    }
}