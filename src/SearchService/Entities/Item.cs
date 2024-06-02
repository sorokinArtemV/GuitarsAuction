using MongoDB.Entities;

namespace SearchService.Entities;

public class Item : Entity
{
    public string? Seller { get; set; }
    public string? Winner { get; set; }
    public int SoldAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime AuctionEnd { get; set; }
    
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int Year { get; set; }
    public string? Type { get; set; }
    public string? Color { get; set; }
    public string? CelebrityOwned { get; set; }
    public bool HasCelebritySignature { get; set; }
    public string? SignatureDetails { get; set; }
    public string? Condition { get; set; }
    public string? Description { get; set; }
    
    public int CurrentHighBid { get; set; }
    public int ReservePrice { get; set; }
}