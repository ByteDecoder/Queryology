using ByteDecoder.Queryology.Tests.Data;

namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeInMemoryDbContextTwo : QueryBase<InMemoryDbContext>
  {
    public QueryTypeInMemoryDbContextTwo(InMemoryDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {
      Data = new { Id = 1, Name = "Charcoral" };
    }
  }
}