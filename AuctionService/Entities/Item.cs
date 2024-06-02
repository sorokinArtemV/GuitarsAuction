using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionService.Entities;

[Table("Items")]
public class Item
{
    public Guid Id { get; set; }
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

    // 
    public Auction? Auction { get; set; }
    public Guid AuctionId { get; set; }
}