namespace DotNet8WebApi.MiniKpaySample.Shared;

public static class CommonQuery
{
    public static string IsExistCustomerCode { get; } =
        @"select * from Tbl_Customer with (nolock) where CustomerCode = @CustomerCode";

    public static string TransactionHistoryByCustomerCode { get; } =
        @"select CTH.* from [dbo].[Tbl_CustomerTransactionHistory] CTH
                                                    inner join Tbl_Customer C on CTH.FromMobileNo = C.MobileNo
                                                    where CustomerCode = @CustomerCode";

    public static string IsExistTransactionDate { get; } =
        @"select * from Tbl_Customer with (nolock) where TransactionDate = @TransactionDate";

    public static string TransactionHistoryByDatetime { get; } =
        @"select CTH.* from [dbo].[Tbl_CustomerTransactionHistory] CTH
                                                     inner join Tbl_Customer C on CTH.FromMobileNo = C.MobileNo
                                                     where TransactionDate = @TransactionDate";

    public static string InsertTransactionHistory { get; } =
        @"INSERT INTO Tbl_CustomerTransactionHistory (FromMobileNo, ToMobileNo, Amount, TransactionDate)
                                                         VALUES (@FromMobileNo, @ToMobileNo, @Amount, @TransactionDate)";
}