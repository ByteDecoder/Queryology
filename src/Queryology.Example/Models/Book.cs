using System;
using System.Collections.Generic;

namespace Queryology.Example.Models
{
  public class Book
  {
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime PublishedOn { get; set; }
    public string Publisher { get; set; }
    public decimal Price { get; set; }
    /// <summary>
    /// Holds the URL to get the image of the book
    /// </summary>
    public string ImageUrl { get; set; }

    // Relationships
    public PriceOffer Promotion { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
    public IEnumerable<BookAuthor> AuthorsLink { get; set; }
  }
}