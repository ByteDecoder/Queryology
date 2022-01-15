using ByteDecoder.Queryology.Example.Models;
using ByteDecoder.Queryology.Providers.ObjectDumper;

namespace ByteDecoder.Queryology.Example;

internal static class Program
{
    internal static void Main()
    {
        // Using an EF Core provider
        using var dbContext = new EfCoreContext();
        var totalQueries = new QueryologyEngineBuilder<EfCoreContext>()
            .Configure(options => options.DataContextProvider = dbContext)
            .AddObjectDumper()
            .Build()
            .Execute();

        Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed by QueryologyEngine<EfCoreContext>: {totalQueries}");
        Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");
        Console.ReadLine();

        // Only to work with LINQ to Objects
        using var nullDbContext = new NullDbContext();
        totalQueries = new QueryologyEngineBuilder<NullDbContext>()
        .Configure(options => options.DataContextProvider = nullDbContext)
          .AddObjectDumper()
          .Build()
          .Execute();

        Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed by QueryologyEngine<NullDbContext>: {totalQueries}");
        Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");

        Console.ReadLine();
    }
}
