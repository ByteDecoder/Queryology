using ByteDecoder.Queryology.Abstractions;

namespace ByteDecoder.Queryology.Tests.Queries;

/// <summary>
///
/// </summary>
public class QueryTypeNullDbContextThree : QueryBase<NullDbContext>
{
    public QueryTypeNullDbContextThree(
        NullDbContext dataContext,
        IObjectDisplayer objectDisplayer) : base(dataContext, objectDisplayer) { }

    /// <summary>
    ///
    /// </summary>
    public override bool Executable => false;

    /// <summary>
    ///
    /// </summary>
    public override void Execute() { }
}
