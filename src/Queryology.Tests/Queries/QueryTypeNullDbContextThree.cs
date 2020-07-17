namespace ByteDecoder.Queryology.Tests.Queries
{
  public class QueryTypeNullDbContextThree: QueryBase<NullDbContext>
  {
    public override bool Executable => false;

    public override void Execute()
    {

    }
  }
}