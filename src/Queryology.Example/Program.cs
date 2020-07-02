using System;
using ByteDecoder.Queryology;
using Queryology.Example.Models;

namespace Queryology.Example
{
  class Program
  {
    static void Main(string[] args)
    {
      using var dbContext = new EfCoreContext();
      var totalQueries = new QueryologyEngine<EfCoreContext>(dbContext).Execute();

      Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed: {totalQueries}");
      Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");
      Console.ReadLine();
    }
  }
}
