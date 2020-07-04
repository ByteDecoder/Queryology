using System;

namespace ByteDecoder.Queryology.Example.Queries
{
  public class LinqToObjectsQuery: QueryBase<NullDbContext>
  {
    public LinqToObjectsQuery(NullDbContext dataContext) : base(dataContext) { }

    public override void Execute()
    {
      Console.WriteLine("Some LINQ to Objects code here");
    }
  }
}