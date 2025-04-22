namespace Auction.Core;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal HighestPrice { get; set; }
    public string HighestBidder { get; set; }
    public DateTime Deadline { get; set; }
}