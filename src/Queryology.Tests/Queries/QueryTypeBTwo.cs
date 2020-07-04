using ByteDecoder.Queryology.Tests.Data;

namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeBTwo: QueryBase<InMemoryDbContext>
  {
    public QueryTypeBTwo(InMemoryDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}