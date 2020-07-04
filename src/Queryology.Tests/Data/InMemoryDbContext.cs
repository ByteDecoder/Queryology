using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.Data
{
  public class InMemoryDbContext: DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseInMemoryDatabase(databaseName: "InMemoryTestDB");
  }
}