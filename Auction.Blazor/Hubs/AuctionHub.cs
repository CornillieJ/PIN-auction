using Auction.Core;
using Microsoft.AspNetCore.SignalR;

namespace Auction.Blazor.Hubs;

public class AuctionHub : Hub
{
    private readonly IAuctionService _auctionService;

    public AuctionHub(IAuctionService auctionService)
    {
        _auctionService = auctionService;
    }

    public async Task<Product> PlaceBid(Guid productId, string bidder, decimal bidPrice)
    {
        var product = await _auctionService.BidAsync(productId, bidder, bidPrice);
        await Clients.All.SendAsync("ReceiveBid", product);
        return product;
    }
}