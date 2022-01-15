using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Abstractions;
/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
public class QueryologyEngineOptions<T>
    where T : DbContext
{
    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public T? DataContextProvider { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <value></value>
    public DisplayObjectData? ObjectDisplayerProvider { get; set; }

    /// <summary>
    ///
    /// </summary>
    public IQueryFactory<T>? QueryFactoryProvider { get; set; }
}
