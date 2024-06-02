using AuctionService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<AuctionDbContext>()!);
    }

    private static void SeedData(AuctionDbContext context)
    {
        context.Database.Migrate();

        if (context.Auctions.Any())
        {
            Console.WriteLine("Already have data - no need to seed");
            return;
        }

        List<Auction> auctions =
        [
            new Auction
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(10),
                Item = new Item
                {
                    Make = "Ibanez",
                    Model = "JEM77",
                    Year = 1995,
                    Type = "Electric",
                    Color = "Blue Floral Pattern",
                    CelebrityOwned = "Steve Vai",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the back of the headstock",
                    Condition = "Very Good",
                    Description = "A stunning Ibanez JEM77, known for its unique blue floral pattern and exceptional sound quality. Previously owned and played by guitar legend Steve Vai, it comes with his signature on the back of the headstock. A prized piece for any serious guitar collector."
                }
            },
            new Auction
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                Status = Status.Live,
                ReservePrice = 90000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(60),
                Item = new Item
                {
                    Make = "Ibanez",
                    Model = "JS1CR",
                    Year = 2018,
                    Type = "Electric",
                    Color = "Chrome",
                    CelebrityOwned = "Joe Satriani",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the body next to the bridge",
                    Condition = "Mint",
                    Description = "This Ibanez JS1CR Chrome Boy is a rare find, with a reflective chrome finish that's sure to stand out. Owned and signed by the virtuoso Joe Satriani, it's in mint condition and a true collector's dream."
                }
            },
            new Auction
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(4),
                Item = new Item
                {
                    Make = "Gibson",
                    Model = "Les Paul Standard",
                    Year = 1959,
                    Type = "Electric",
                    Color = "Sunburst",
                    CelebrityOwned = "Jimmy Page",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the pickguard",
                    Condition = "Good",
                    Description = "A legendary 1959 Gibson Les Paul Standard, once graced by the iconic Jimmy Page. Known for its rich tone and sustain, this guitar bears the signature of rock royalty."
                }

            },
            // 4 Mercedes SLK
            new Auction
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                Status = Status.ReserveNotMet,
                ReservePrice = 50000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(-10),
                Item = new Item
                {
                    Make = "Sawtooth",
                    Model = "M24",
                    Year = 2020,
                    Type = "Electric",
                    Color = "Primal Red",
                    CelebrityOwned = "Michael Angelo Batio",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the body",
                    Condition = "Mint",
                    Description = "A Sawtooth M24 electric guitar in Primal Red, designed in collaboration with the legendary shredder Michael Angelo Batio. Known for its speed and precision, this guitar is signed by Batio himself and is a limited edition model sought after by collectors and players alike."
                }
            },
            new Auction
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(30),
                Item = new Item
                {
                    Make = "KISS",
                    Model = "Axe",
                    Year = 1978,
                    Type = "Bass",
                    Color = "Black",
                    CelebrityOwned = "Gene Simmons",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the body of the guitar",
                    Condition = "Excellent",
                    Description = "This iconic Axe bass guitar was used by Gene Simmons during the KISS 'Alive II' tour. It features his signature on the body and is in excellent condition, a must-have for any collector or fan."
                }
            },
            new Auction
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(45),
                Item = new Item
                {
                    Make = "Fender",
                    Model = "Stratocaster",
                    Year = 1965,
                    Type = "Electric",
                    Color = "Olympic White",
                    CelebrityOwned = "Jimi Hendrix",
                    HasCelebritySignature = false,
                    SignatureDetails = null,
                    Condition = "Fair",
                    Description = "An Olympic White Fender Stratocaster reminiscent of the one played by Jimi Hendrix. This guitar embodies the spirit of the '60s rock revolution."
                }
            },
            new Auction
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                Status = Status.Live,
                ReservePrice = 150000,
                Seller = "alice",
                AuctionEnd = DateTime.UtcNow.AddDays(13),
                Item = new Item
                {
                    Make = "ESP",
                    Model = "Explorer",
                    Year = 1984,
                    Type = "Electric",
                    Color = "Black",
                    CelebrityOwned = "James Hetfield",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the body with a silver marker",
                    Condition = "Good",
                    Description = "A menacing Black ESP Explorer, echoing the aggressive style of James Hetfield. This guitar has been a staple in Metallica's heavy metal sound."
                }
            },
            // 8 Audi R8
            new Auction
            {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                Status = Status.Live,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(19),
                Item = new Item
                {
                    Make = "Traditional Mongolian",
                    Model = "Morin Khuur",
                    Year = 2016, // Assuming the year the band gained international recognition
                    Type = "String",
                    Color = "Natural Wood",
                    CelebrityOwned = "Gala of The Hu Band",
                    HasCelebritySignature = true,
                    SignatureDetails = "Gala's signature, authenticating its use in performances",
                    Condition = "Excellent",
                    Description = "A distinguished Morin Khuur, crafted with traditional Mongolian techniques, known for its deep resonance and captivating sound. Played by Gala of The Hu band, this instrument has a storied history, having been a central feature in the band's 'Hunnu Rock' performances. Its value is enhanced by its cultural significance, making it a coveted piece for collectors."
                }

            },
            new Auction
            {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "tom",
                AuctionEnd = DateTime.UtcNow.AddDays(20),
                Item = new Item
                {
                    Make = "Yamaha",
                    Model = "Attitude",
                    Year = 2001,
                    Type = "Bass",
                    Color = "Sunburst",
                    CelebrityOwned = "Billy Sheehan",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the body",
                    Condition = "Excellent",
                    Description = "Billy Sheehan's signature Yamaha Attitude bass, known for its powerful sound and durability. This particular piece was used during his 2001 tour with Steve Vai and features his autograph."
                }
            },
            // 10 Ford Model T
            new Auction
            {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                Status = Status.Live,
                ReservePrice = 20000,
                Seller = "bob",
                AuctionEnd = DateTime.UtcNow.AddDays(48),
                Item = new Item
                {
                    Make = "Modulus",
                    Model = "Flea Bass",
                    Year = 1993,
                    Type = "Bass",
                    Color = "Silver Sparkle",
                    CelebrityOwned = "Flea",
                    HasCelebritySignature = true,
                    SignatureDetails = "Signed on the pickguard",
                    Condition = "Very Good",
                    Description = "A Modulus Flea Bass in a dazzling silver sparkle finish, once owned by Flea of the Red Hot Chili Peppers. It comes with his signature and is known for its exceptional playability and funky tone."
                }
            }
        ];

        context.AddRange(auctions);

        context.SaveChanges();
    }
}