using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Tests.Queries;

public class QueryTypeNullDbContextTwo : QueryBase<NullDbContext>
{
    public QueryTypeNullDbContextTwo(
        NullDbContext dataContext,
        IObjectDisplayer objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {

    }
}
