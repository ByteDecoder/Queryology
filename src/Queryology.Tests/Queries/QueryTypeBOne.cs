using ByteDecoder.Queryology;
using Queryology.Tests.Data;

namespace Queryology.Tests.Queries
{
  public class QueryTypeBOne : QueryBase<InMemoryDbContext>
  {
    public override bool Executable => false;
    public QueryTypeBOne(InMemoryDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {
    }
  }
}