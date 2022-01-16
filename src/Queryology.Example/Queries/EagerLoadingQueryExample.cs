using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Example.Models;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Example.Queries;

public class EagerLoadingQueryExample : QueryBase<EfCoreContext>
{
    public EagerLoadingQueryExample(
        EfCoreContext dataContext,
        DisplayObjectData objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {
        Data = DataContext.Books
          .Include(b => b.AuthorsLink)
            .ThenInclude(a => a.Author)

          .Include(b => b.Reviews)
          .Include(b => b.Promotion)
          .First();

        DisplayData("Eager Loading EF Core Query - EagerLoadingQueryExample", 3);
    }
}
