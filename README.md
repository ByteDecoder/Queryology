# Queryology

![CI](https://github.com/ByteDecoder/Queryology/workflows/CI/badge.svg)
[![CodeQL](https://github.com/ByteDecoder/Queryology/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/ByteDecoder/Queryology/actions/workflows/codeql-analysis.yml)
[![Maintainability](https://api.codeclimate.com/v1/badges/5636af5394315faa7bd8/maintainability)](https://codeclimate.com/github/ByteDecoder/Queryology/maintainability)
[![Test Coverage](https://api.codeclimate.com/v1/badges/5636af5394315faa7bd8/test_coverage)](https://codeclimate.com/github/ByteDecoder/Queryology/test_coverage)
![License](https://img.shields.io/badge/license-MIT-green)

You can find the documentation for previous versions < 1.0.0 here [documentation until v0.4.3 here](DOCUMENTATION_UNTIL_0.4.3.md)

Minimalist query engine executor used with Entity Framework Core + LINQ for quick experiments

Targeted to .Net 8

## Installation

Install the [Queryology NuGet Package](https://www.nuget.org/packages/ByteDecoder.Queryology).

### Package Manager Console

```porwershell
Install-Package ByteDecoder.Queryology
Install-Package ByteDecoder.Queryology.Providers.ObjectDumper
```

### .NET Core CLI

```bash
dotnet add package ByteDecoder.Queryology
dotnet add package ByteDecoder.Queryology.Providers.ObjectDumper
```

## Examples and usage

If you are exploring a query or learning _Entity Framework core_, and want to analyze, understand, and doing some experiments, but you do not want to spend a lot of time doing boilerplate infrastructure. Enter the **Queryology Engine**.

By using it, allow you to stay focus reviewing and writing your queries, executing them, and you can disable them for not execution in runtime with the minimal code changes.

The basic theory that you need:

- **Queryology** NuGet package installed and _Object Dumper_ provider
- Your _EF Core DbContext class_, or if you want to use only _LINQ to Objects_, **Queryology** provides a default _NullDbContext_ to avoid setting one by yourself
- Have a query class per each one of your experiments
- Inherit and implement _QueryBase\<T\>_ where **T** is the type of your _EF Core DbContext class_
- **QueryBase\<T\>** Uses a delegate to display the output. An **ObjectDumper** provider from Microsoft is included as base for exploring your Linq results
- Don't forget to add a _logger_ in your _EF Core DbContext class_ to analyze the _SQL output_
- Just call an instance of **QueryologyEngine** with your _EF Core DbContext class_ and, it will find for you all your query classes that inherit from **QueryBase\<T\>** and it will execute them
- Enjoy

**QueryBase\<T\>** Provides you:

- _DataContext property_ which holds the reference to the provided _EF Core DbContext class_
- _DisplayData method_ to write in the console the structure of your query result using the **Data** property
- _Data property_ defined as _object_ since you can project _anonymous types_ with LINQ
- _Executable property_ that is overridable to set to **false** if you do not want this rule to be executed by _QueryologyEngine_

Minimalist EF Core DbContext example code:

```csharp
// Create your EF Core DbContext class
public class MyDbCoreContext : DbContext { ... }

// Write your query class(es) and inherit from QueryBase<T> where T
// is your EF Core DbContext class
public class MyQuery : QueryBase<MyDbCoreContext>
{
    public MyQuery(MyDbCoreContext dbContext, DisplayObjectData objectDisplayer)
      : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {
        Data = DataContext.Books
          .Include(b => b.AuthorsLink)
            .ThenInclude(a => a.Author)

          .Include(b => b.Reviews)
          .Include(b => b.Promotion)
          .First();

        DisplayData($"{typeof(MyQuery)} query results:", 3);
    }
}

// In your .Net Core application, instantiate the engine and execute it!
using ByteDecoder.Queryology;
using ByteDecoder.Queryology.Providers.ObjectDumper;

class Program
{
    static void Main(string[] args)
    {
        using var dbContext = new MyDbCoreContext();
        var totalQueries = new QueryologyEngineBuilder<EfCoreContext>()
            .Configure(options => options.DataContextProvider = dbContext)
            .AddObjectDumper()
            .Build()
            .Execute();


        Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed: {totalQueries}");
        Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");
        Console.ReadLine();
    }
}
```

Minimalist EF Core only with LINQ to Objects example code:

```csharp
// Write your query class(es) and inherit from QueryBase<T> and use NullDbContext
// as your type T
public class LinqToObjectsQuery : QueryBase<NullDbContext>
{
    public LinqToObjectsQuery(NullDbContext dbContext, DisplayObjectData objectDisplayer)
      : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {
        Console.WriteLine("Some LINQ to Objects code here");
    }
}

// In your .Net Core application, instantiate the engine and execute it!
using ByteDecoder.Queryology;
using ByteDecoder.Queryology.Providers.ObjectDumper;

class Program
{
    static void Main(string[] args)
    {
        using var nullDbContext = new NullDbContext();
        totalQueries = new QueryologyEngineBuilder<NullDbContext>()
          .Configure(options => options.DataContextProvider = nullDbContext)
          .AddObjectDumper()
          .Build()
          .Execute();


        Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed: {totalQueries}");
        Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");
        Console.ReadLine();
    }
}
```

Mark a _Query class_ to be ignored and not to be executed at runtime:

```csharp
// Just override the Executable property; and set it to false.
public class NeverAgainQuery : QueryBase<MyDbCoreContext>
{
    public NeverAgainQuery(EfCoreContext dbContext, DisplayObjectData objectDisplayer)
      : base(dataContext, objectDisplayer) { }

    public override bool Executable => false;

    public override void Execute()
    {
        Console.WriteLine("Never again.. I will never get executwed by QueryologyEngine =(");
        throw new NotImplementedException();
    }
}
```

Ignore excluded queries and execute all queries under type **T**

```csharp
// Changing the default value of *IgnoreExcludedQueries* resets to its true default value
// after the engine completes all the query processing
using var nullDbContext = new NullDbContext();
var queryologyEngine = new QueryologyEngineBuilder<NullDbContext>()
  .Configure(options => options.DataContextProvider = nullDbContext)
  .AddObjectDumper()
  .Build();

var totalQueries = queryologyEngine
  .IgnoreExcludedQueries(false)
  .Execute();
```

That is all, you can continue adding more queries and do not bother about the infrastructure

## Running Example .Net Core Console App

First create the example database and apply the migrations with:

```bash
cd ./src
dotnet ef database update -p ./Queryology.Example
```

Then run the example console project:

```bash
cd Queryology.Example/
dotnet run
```

## Contributing

Bug reports and pull requests are welcome on GitHub at <https://github.com/ByteDecoder/Queryology>.

Copyright (c) 2020 [Rodrigo Reyes](https://twitter.com/bytedecoder) released under the MIT license
