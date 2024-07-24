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

    //public async Task<List<CustomerTransactionHistoryModel>> GenerateTransactionHistory(int count)
    //{
    //    var model = new List<CustomerTransactionHistoryModel>();
    //    var random = new Random();

    //    for (int i = 0; i < count; i++)
    //    {
    //        var item = new CustomerTransactionHistoryModel
    //        {
    //            FromMobileNo = GenerateRandomMobileNumber(random),
    //            ToMobileNo = GenerateRandomMobileNumber(random),
    //            TransactionDate = DateTime.UtcNow.AddDays(-random.Next(0, 365)),
    //            Amount = (decimal)(random.NextDouble() * 1000)
    //        };
    //        model.Add(item);
    //    }

    //    foreach (var item in model)
    //    {
    //        await _db.ExecuteAsync(CommonQuery.InsertTransactionHistory, item);
    //    }
    //    return model;
    //}

    //private string GenerateRandomMobileNumber(Random random)
    //{
    //    return "09" + random.Next(100000000, 999999999).ToString();
    //}
}