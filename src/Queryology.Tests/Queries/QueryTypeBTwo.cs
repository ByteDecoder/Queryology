using ByteDecoder.Queryology;
using Queryology.Tests.Data;

namespace Queryology.Tests.Queries
{
  public class QueryTypeBTwo : QueryBase<InMemoryDbContext>
  {
    public QueryTypeBTwo(InMemoryDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}