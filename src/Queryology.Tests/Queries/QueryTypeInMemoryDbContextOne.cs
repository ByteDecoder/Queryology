using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Tests.Data;

namespace ByteDecoder.Queryology.Tests.Queries;

public class QueryTypeInMemoryDbContextOne : QueryBase<InMemoryDbContext>
{
    public QueryTypeInMemoryDbContextOne(
        InMemoryDbContext dataContext,
        IObjectDisplayer objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override bool Executable => false;

    public override void Execute()
    {
    }
}

