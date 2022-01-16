using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Example.Queries;

public class LinqToObjectsQuery : QueryBase<NullDbContext>
{
    public LinqToObjectsQuery(
        NullDbContext dataContext,
        DisplayObjectData objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {
        Console.WriteLine("Some LINQ to Objects code here");
    }
}

