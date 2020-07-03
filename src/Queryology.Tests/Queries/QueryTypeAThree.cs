using ByteDecoder.Queryology;

namespace Queryology.Tests.Queries
{
  public class QueryTypeAThree : QueryBase<NullDbContext>
  {
    public override bool Executable => false;
    public QueryTypeAThree(NullDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}