using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Queryology.Example.Models
{
  public class EfCoreContext : DbContext
  {
    private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<PriceOffer> PriceOffers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<BookAuthor>().HasKey(x => new { x.BookId, x.AuthorId });

      modelBuilder.Entity<Book>().HasData(SeedData.BooksData());
      modelBuilder.Entity<Review>().HasData(SeedData.ReviewsData());
      modelBuilder.Entity<Author>().HasData(SeedData.AuthorsData());
      modelBuilder.Entity<BookAuthor>().HasData(SeedData.BookAuthors());
      modelBuilder.Entity<PriceOffer>().HasData(SeedData.PromotionsData());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      Console.WriteLine(Directory.GetCurrentDirectory());

      var currentDirectory = Directory.GetCurrentDirectory();
      var dbPath = "";

      if (currentDirectory.Contains("Queryology.Example")) 
        dbPath = "ExampleDatabase.db";
      else 
        dbPath = Path.Combine(Directory.GetCurrentDirectory(), "/Queryology.Example/ExampleDatabase.db");
      
      Console.WriteLine($"dbPath => {dbPath}");
     optionsBuilder
      .UseLoggerFactory(_loggerFactory)
      .EnableSensitiveDataLogging()
      .UseSqlite($"Data source={dbPath}");
    }
  }
}