using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Tests.Data;

namespace ByteDecoder.Queryology.Tests.Queries;

public class QueryTypeInMemoryDbContextTwo : QueryBase<InMemoryDbContext>
{
    public QueryTypeInMemoryDbContextTwo(
        InMemoryDbContext dataContext,
        DisplayObjectData objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override void Execute()
    {
        Data = new { Id = 1, Name = "Charcoral" };

        DisplayData("Test");
    }
}
