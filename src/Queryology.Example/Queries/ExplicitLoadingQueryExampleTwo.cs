using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Example.Models;
using ByteDecoder.Queryology.Providers.ObjectDumper;

namespace ByteDecoder.Queryology.Example.Queries;

public class ExplicitLoadingQueryExampleTwo : QueryBase<EfCoreContext>
{
    public ExplicitLoadingQueryExampleTwo(
        EfCoreContext dataContext,
        DisplayObjectData objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {
        var book = DataContext.Books.First();
        var numReviews = DataContext.Entry(book)
          .Collection(c => c.Reviews)
          .Query().Count();

        var starRatings = DataContext.Entry(book)
          .Collection(c => c.Reviews)
          .Query().Select(x => x.NumStars)
          .ToList();

        DisplayData("Eager Loading EF Core Query # ExplicitLoadingQueryExampleTwo", 3);
        Console.WriteLine($"Review Count => {numReviews}");
        ObjectDumper.Write(starRatings);
    }
}
