namespace Auction.Core;

public interface IAuctionService
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductByIdAsync(Guid auctionId);
    Task<Product> BidAsync(Guid productId, string bidderName, decimal bidPrice);
}