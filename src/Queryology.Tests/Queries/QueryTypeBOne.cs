using ByteDecoder.Queryology.Tests.Data;

namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeBOne: QueryBase<InMemoryDbContext>
  {
    public override bool Executable => false;
    public QueryTypeBOne(InMemoryDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {
    }
  }
}