namespace ByteDecoder.Queryology.Example.Models;

public class Book
{
    public int BookId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime PublishedOn { get; set; }
    public string? Publisher { get; set; }
    public decimal Price { get; set; }
    /// <summary>
    /// Holds the URL to get the image of the book
    /// </summary>
    public string? ImageUrl { get; set; }

    // Relationships
    public PriceOffer? Promotion { get; set; }
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<BookAuthor> AuthorsLink { get; set; } = new List<BookAuthor>();
}
