using System.Linq;
using ByteDecoder.Queryology.Example.Models;
using Microsoft.EntityFrameworkCore;
using Queryology.Example.Models;

namespace ByteDecoder.Queryology.Example.Queries
{
  public class EagerLoadingQueryExample: QueryBase<EfCoreContext>
  {
    public EagerLoadingQueryExample(EfCoreContext dataContext) : base(dataContext) { }

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
}