using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Tests.Queries;

public class QueryTypeNullDbContextOne : QueryBase<NullDbContext>
{
    public QueryTypeNullDbContextOne(
        NullDbContext dataContext,
        DisplayObjectData objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {

    }
}

