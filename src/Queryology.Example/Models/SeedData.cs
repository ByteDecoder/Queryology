using System;
using System.Collections.Generic;

namespace ByteDecoder.Queryology.Example.Models
{
  public static class SeedData
  {
    public static IEnumerable<Book> BooksData() => new[]
  {
        new Book
        {
          BookId = 1,
          Title = "C# Volume 1",
          Description = "Learn C# Series",
          PublishedOn = Convert.ToDateTime("01/02/2002"),
          Publisher = "The Ematoma United",
          Price = 25.00M,
          ImageUrl = "www.sample.com"
        },

        new Book
        {
          BookId = 2,
          Title = "C# Volume 2",
          Description = "Learn C# Series",
          PublishedOn = Convert.ToDateTime("01/02/2003"),
          Publisher = "The Ematoma United",
          Price = 27.00M,
          ImageUrl = "www.sample.com"
        },

        new Book
        {
          BookId = 3,
          Title = "C# Volume 3",
          Description = "Learn C# Series",
          PublishedOn = Convert.ToDateTime("01/02/2004"),
          Publisher = "The Ematoma United",
          Price = 30.00M,
          ImageUrl = "www.sample.com"
        }
      };

    public static IEnumerable<Review> ReviewsData() => new[]
      {
        new Review { ReviewId = 1, BookId = 1, Comment = "Supper Lupper", NumStars = 5, VoterName = "Jacinto Squire" },
        new Review { ReviewId = 2, BookId = 1, Comment = "Noyhing to say...", NumStars = 3, VoterName = "Lucretia Wells" },
        new Review { ReviewId = 3, BookId = 2, Comment = "Outstandingly thought out! This is new school.", NumStars = 5, VoterName = "Jacinto Squire" },
        new Review { ReviewId = 4, BookId = 2, Comment = "Nice use of magenta in this concept!", NumStars = 3, VoterName = "Lucretia Wells" },
        new Review { ReviewId = 5, BookId = 3, Comment = "So radiant and splendid!!", NumStars = 5, VoterName = "Jacinto Squire" },
        new Review { ReviewId = 6, BookId = 3, Comment = "This shot blew my mind.", NumStars = 3, VoterName = "Julia Akashiya" },
        new Review { ReviewId = 7, BookId = 3, Comment = "Fabulous work you have here.", NumStars = 5, VoterName = "Morgana Avila" },
        new Review { ReviewId = 8, BookId = 3, Comment = "This shapes has navigated right into my heart.", NumStars = 3, VoterName = "Danica Ayala" }
      };

    public static IEnumerable<Author> AuthorsData() => new[]
      {
        new Author { AuthorId = 1, Name="Mary Hogan" },
        new Author { AuthorId = 2, Name="Molly Kramer" },
        new Author { AuthorId = 3, Name="Rhonda Ferguson" },
        new Author { AuthorId = 4, Name="Jessie Salinas" },
        new Author { AuthorId = 5, Name="Maryam Jenkins" },
        new Author { AuthorId = 6, Name="Adele Gonzalez" },
        new Author { AuthorId = 7, Name="Yasmine Chapman" },
      };

    public static IEnumerable<BookAuthor> BookAuthors() => new[]
      {
        new BookAuthor { AuthorId = 5, BookId=1, Order = 1 },
        new BookAuthor { AuthorId = 7, BookId=1, Order = 2 },
        new BookAuthor { AuthorId = 2, BookId=1, Order = 3 },

        new BookAuthor { AuthorId=1, BookId=2, Order = 1 },
        new BookAuthor { AuthorId=4, BookId=2, Order = 2 },
        new BookAuthor { AuthorId=7, BookId=2, Order = 3 },

        new BookAuthor { AuthorId=1, BookId=3, Order = 1 },
        new BookAuthor { AuthorId=2, BookId=3, Order = 2 },
        new BookAuthor { AuthorId=3, BookId=3, Order = 3 },
        new BookAuthor { AuthorId=4, BookId=3, Order = 4 },
        new BookAuthor { AuthorId=5, BookId=3, Order = 5 },
        new BookAuthor { AuthorId=6, BookId=3, Order = 6 },
        new BookAuthor { AuthorId=7, BookId=3, Order = 7 },
      };

    public static IEnumerable<PriceOffer> PromotionsData() => new[]
      {
        new PriceOffer { PriceOfferId=1, BookId=1, NewPrice=15.00M, PromotionalText="Get the saga!!!" },
        new PriceOffer { PriceOfferId=2, BookId=2, NewPrice=23.99M, PromotionalText="Do not be behind!!!" }
      };

  }
}