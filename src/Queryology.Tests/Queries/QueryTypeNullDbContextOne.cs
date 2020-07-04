namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeNullDbContextOne: QueryBase<NullDbContext>
  {
    public QueryTypeNullDbContextOne(NullDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}