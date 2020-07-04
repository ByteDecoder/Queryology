namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeNullDbContextThree: QueryBase<NullDbContext>
  {
    public override bool Executable => false;
    public QueryTypeNullDbContextThree(NullDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {

    }
  }
}