![CI](https://github.com/ByteDecoder/Queryology/workflows/CI/badge.svg)
[![Maintainability](https://api.codeclimate.com/v1/badges/5636af5394315faa7bd8/maintainability)](https://codeclimate.com/github/ByteDecoder/Queryology/maintainability)

# Queryology
Minimalist query engine executor used with Entity Framework Core + LINQ for quick experiments

Targeted to .Net Core 3.1

## Installation

Install the [Queryology NuGet Package](https://www.nuget.org/packages/ByteDecoder.Queryology).

### Package Manager Console

```
Install-Package ByteDecoder.Queryology
```

### .NET Core CLI

```
dotnet add package ByteDecoder.Queryology
```

## Examples and usage

If you are exploring a query or learning *Entity Framework core*,  and want to analyze, understand, and doing some experiments, but you do not want to spend a lot of time doing boilerplate infrastructure. Enter the **Queryology Engine**.

By using it, allow you to stay focus reviewing and writing your queries, executing them, and you can disable them for not execution in runtime with the minimal code changes.

The basic theory that you need:

- **Queryology** NuGet package installed
- Your *EF Core DbContext class*, or if you want to use only *LINQ to Objects*, **Queryology** provides a default *NullDbContext* to avoid setting one by yourself
- Have a query class per each one of your experiments
- Inherit and implement *QueryBase\<T\>* where **T** is the type of your *EF Core DbContext class*
- **QueryBase\<T\>** Uses an **ObjectDumper** from Microsoft for exploring your Linq results
- Don't forget to add a *logger* in your *EF Core DbContext class* to analyze the *SQL output*
- Just call an instance of **QueryologyEngine** with your *EF Core DbContext class* and, it will find for you all your query classes that inherit from  **QueryBase\<T\>** and it will execute them
- Enjoy

**QueryBase\<T\>** Provides you:

- *DataContext property* which holds the reference to the provided *EF Core DbContext class*
- *DisplayData method* to write in the console the structure of your query result using the **Data** property
- *Data property* defined as *dynamic* since you can project *anonymous types* with LINQ
- *Executable property* that is overridable to set to **false** if you do not want this rule to be executed by *QueryologyEngine*

Minimalist EF Core DbContext example code:

```csharp
// Create your EF Core DbContext class
public class MyDbCoreContext : DbContext { ... }

// Write your query class(es) and inherit from QueryBase<T> where T
// is your EF Core DbContext class
public class MyQuery : QueryBase<MyDbCoreContext>
{
  public MyQuery(MyDbCoreContext dataContext) : base(dataContext) { }

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
class Program
{
  static void Main(string[] args)
  {
    using var dbContext = new MyDbCoreContext();
    var totalQueries = new QueryologyEngine<MyDbCoreContext>(dbContext).Execute();

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
  public LinqToObjectsQuery(NullDbContext dataContext) : base(dataContext) { }

  public override void Execute()
  {
    Console.WriteLine("Some LINQ to Objects code here");
  }
}

// In your .Net Core application, instantiate the engine and execute it!
class Program
{
  static void Main(string[] args)
  {
    using var nullDbContext = new NullDbContext();
    var totalQueries = new QueryologyEngine<NullDbContext>(nullDbContext).Execute();

    Console.WriteLine($"\n🦄🦄 Total Queries allowed to be executed: {totalQueries}");
    Console.WriteLine("🐵🐵 Press Enter to continue... 🐵🐵");
    Console.ReadLine();
  }
}
```

Mark a *Query class* to be ignored and not to be executed at runtime:

```csharp
// Just override the Executable property; and set it to false.
public class NeverAgainQuery : QueryBase<MyDbCoreContext>
{
  public override bool Executable => false;

  public NeverAgainQuery(EfCoreContext dataContext) : base(dataContext) { }

  public override void Execute()
  {
    Console.WriteLine("Never again.. I will never get executwed by QueryologyEngine =(");
    throw new NotImplementedException();
  }
}
```

Ignore excluded queries and execute all queries under type **T**

```csharp
// Changing the default value of *IgnoreExcludedQueries* affect your current engine instance.
// If you want to call again in the same code block, you need to pass **true** 
// if you do not want that behavior.
using var nullDbContext = new NullDbContext();
var totalQueries = new QueryologyEngine<NullDbContext>(nullDbContext)
                       .IgnoreExcludedQueries(false)
                       .Execute();
```

That is all, you can continue adding more queries and do not bother about the infrastructure

## Running Example .Net Core Console App

First create the example database and apply the migrations with:

```bash
$ cd ./src
$ dotnet ef database update -p ./Queryology.Example
```

Then run the example console project:

```bash
$ cd Queryology.Example/
$ dotnet run
```

## Contributing

Bug reports and pull requests are welcome on GitHub at https://github.com/ByteDecoder/Queryology.


Copyright (c) 2020 [Rodrigo Reyes](https://twitter.com/bytedecoder) released under the MIT license
