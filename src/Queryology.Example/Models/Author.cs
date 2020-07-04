using System.Collections.Generic;
using Queryology.Example.Models;

namespace ByteDecoder.Queryology.Example.Models
{
  public class Author
  {
    public int AuthorId { get; set; }
    public string Name { get; set; }

    // Relationships
    public IEnumerable<BookAuthor> BooksLink { get; set; }
  }
}