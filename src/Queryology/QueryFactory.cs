using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology;

/// <summary>
///
/// </summary>
public class QueryFactory<T> : IQueryFactory<T>
    where T : DbContext
{
    /// <summary>
    /// Creates query instance using reflection.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="constructorParams"></param>
    /// <returns></returns>
    public IQuery<T> Create(Type type, params object[] constructorParams)
    {
        var query = Activator.CreateInstance(type, constructorParams) as IQuery<T>;
        ArgumentNullException.ThrowIfNull(query);

        return query;
    }
}
