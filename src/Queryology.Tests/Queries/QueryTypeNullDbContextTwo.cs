using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Tests.Queries;

public class QueryTypeNullDbContextTwo : QueryBase<NullDbContext>
{
    public QueryTypeNullDbContextTwo(
        NullDbContext dataContext,
        DisplayObjectData objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {

    }
}
