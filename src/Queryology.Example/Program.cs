using System;
using ByteDecoder.Queryology;
using Queryology.Example.Models;

namespace Queryology.Example
{
  class Program
  {
    static void Main(string[] args)
    {
      // Using an EF Core provider
      using var dbContext = new EfCoreContext();
      var totalQueries = new QueryologyEngine<EfCoreContext>(dbContext).Execute();

      Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed by QueryologyEngine<EfCoreContext>: {totalQueries}");
      Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");
      Console.ReadLine();

      // Only to work with LINQ to Objects
      using var nullDbContext = new NullDbContext();
      totalQueries = new QueryologyEngine<NullDbContext>(nullDbContext).Execute();

      Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed by QueryologyEngine<NullDbContext>: {totalQueries}");
      Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");

      Console.ReadLine();
    }
  }
}
