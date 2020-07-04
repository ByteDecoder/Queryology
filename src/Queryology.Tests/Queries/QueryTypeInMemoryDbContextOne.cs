using ByteDecoder.Queryology.Tests.Data;

namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeInMemoryDbContextOne: QueryBase<InMemoryDbContext>
  {
    public override bool Executable => false;
    public QueryTypeInMemoryDbContextOne(InMemoryDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {
    }
  }
}