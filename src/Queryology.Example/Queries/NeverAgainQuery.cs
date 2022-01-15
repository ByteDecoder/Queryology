using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Example.Models;

namespace ByteDecoder.Queryology.Example.Queries;

public class NeverAgainQuery : QueryBase<EfCoreContext>
{
    public NeverAgainQuery(
        EfCoreContext dataContext,
        DisplayObjectData objectDisplayer) : base(dataContext, objectDisplayer) { }

    public override bool Executable => false;

    public override void Execute()
    {
        Console.WriteLine("Never again.. I will never get executed by QueryologyEngine =(");
    }
}
