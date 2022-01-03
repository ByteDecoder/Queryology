namespace ByteDecoder.Queryology.Example.Models;

public class Author
{
    public int AuthorId { get; set; }
    public string? Name { get; set; }

    // Relationships
    public ICollection<BookAuthor> BooksLink { get; set; } = new List<BookAuthor>();
}
