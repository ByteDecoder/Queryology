using ByteDecoder.Queryology;

namespace Queryology.Tests.Queries
{
  public class QueryTypeAOne : QueryBase<NullDbContext>
  {
    public QueryTypeAOne(NullDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}