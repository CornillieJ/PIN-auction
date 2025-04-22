namespace Auction.Core;

public class AuctionService : IAuctionService
{
    private List<Product> _products = 
    [
        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Test Product",
            HighestPrice = 0,
            HighestBidder = "",
            Deadline = DateTime.Now.AddHours(1),
        },        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Test Product2",
            HighestPrice = 0,
            HighestBidder = "",
            Deadline = DateTime.Now.AddHours(1),
        },        new Product
        {
            Id = Guid.NewGuid(),
            Name = "Test Product3",
            HighestPrice = 0,
            HighestBidder = "",
            Deadline = DateTime.Now.AddHours(1),
        },
    ];
    
    public Task<List<Product>> GetProductsAsync()
    {
        return Task.FromResult(_products);
    }

    public Task<Product> GetProductByIdAsync(Guid auctionId)
    {
        return Task.FromResult(_products.FirstOrDefault(p => p.Id == auctionId));
    }

    public Task<Product> BidAsync(Guid productId,string bidderName, decimal bidPrice)
    {
        var product = _products.FirstOrDefault(p => p.Id == productId);
        if (product == null || product.HighestPrice > bidPrice)
            return null;
        product.HighestPrice = bidPrice;
        product.HighestBidder = bidderName;
        product.Deadline = DateTime.Now + TimeSpan.FromHours(1);
        return Task.FromResult(product);
    }
}