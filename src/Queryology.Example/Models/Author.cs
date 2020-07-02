using System.Collections.Generic;

namespace Queryology.Example.Models
{
  public class Author
  {
    public int AuthorId { get; set; }
    public string Name { get; set; }

    // Relationships
    public IEnumerable<BookAuthor> BooksLink { get; set; }
  }
}