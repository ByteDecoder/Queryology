namespace ByteDecoder.Queryology.Example.Queries;

public class LinqToObjectsQuery : QueryBase<NullDbContext>
{
    public LinqToObjectsQuery(NullDbContext dbContext)
        : base(dbContext) { }

    public override void Execute()
    {
        Console.WriteLine("Some LINQ to Objects code here");
    }
}

