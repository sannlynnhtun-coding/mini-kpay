namespace DotNet8WebApi.MiniKpaySample.Features.TransactionHistory;

public class TransactionHistoryRepository
{
    private readonly IDbConnection _db;

    public TransactionHistoryRepository(IDbConnection db)
    {
        _db = db;
    }

    public async Task<bool> IsExistCustomerCode(string customerCode)
    {
        var item = await _db.QueryFirstOrDefaultAsync<CustomerModel>
            (CommonQuery.IsExistCustomerCode, new { CustomerCode = customerCode });

        return item is not null;
    }

    public async Task<List<CustomerTransactionHistoryModel>> TransactionHistoryByCustomerCode(string customerCode)
    {
        var lst = (await _db.QueryAsync<CustomerTransactionHistoryModel>
            (CommonQuery.TransactionHistoryByCustomerCode, new { CustomerCode = customerCode })).ToList();

        return lst;
    }

    public async Task<bool> IsExistTransactionDate(string transactionDate)
    {
        var strDate = transactionDate;
        DateTime datetime = DateTime.Parse(strDate);
        var item = await _db.QueryFirstOrDefaultAsync<CustomerTransactionHistoryModel>(
            CommonQuery.TransactionHistoryByDatetime, new { TransactionDate = datetime });
        return item is not null;
    }

    public async Task<List<CustomerTransactionHistoryModel>> TransactionHistoryByDatetime(string transactionDate)
    {
        var strDate = transactionDate;
        DateTime datetime = DateTime.Parse(strDate);
        var lst = (await _db.QueryAsync<CustomerTransactionHistoryModel>(CommonQuery.TransactionHistoryByDatetime, new
        {
            TransactionDate = datetime
        }))
            .ToList();
        return lst;
    }
}