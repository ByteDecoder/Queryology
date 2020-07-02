namespace Queryology.Example.Models
{
  public class BookAuthor
  {
    public int BookId { get; set; }
    public int AuthorId { get; set; }
    public int Order { get; set; }

    // Relationships
    public Book Book { get; set; }
    public Author Author { get; set; }
  }
}