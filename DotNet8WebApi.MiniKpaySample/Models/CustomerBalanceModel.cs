namespace DotNet8WebApi.MiniKpaySample.Models;

public class CustomerBalanceModel
{
    public int CustomerBalanceId { get; set; }
    public string CustomerCode { get; set; }
    public decimal Balance { get; set; }
}