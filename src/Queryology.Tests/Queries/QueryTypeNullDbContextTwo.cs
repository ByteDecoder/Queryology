namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeNullDbContextTwo: QueryBase<NullDbContext>
  {
    public QueryTypeNullDbContextTwo(NullDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}