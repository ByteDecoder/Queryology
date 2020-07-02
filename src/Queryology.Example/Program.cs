using System;
using ByteDecoder.Queryology;
using Queryology.Example.Models;

namespace Queryology.Example
{
  class Program
  {
    static void Main(string[] args)
    {
      var totalQueries = new QueryologyEngine<EfCoreContext>(new EfCoreContext()).Execute();

      Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed: {totalQueries}");
      Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");
      Console.ReadLine();
    }
  }
}
