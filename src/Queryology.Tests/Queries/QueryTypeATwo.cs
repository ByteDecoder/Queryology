using ByteDecoder.Queryology;

namespace Queryology.Tests.Queries
{
  public class QueryTypeATwo : QueryBase<NullDbContext>
  {
    public QueryTypeATwo(NullDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}