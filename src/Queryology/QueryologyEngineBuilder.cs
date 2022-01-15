using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Providers;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology;

/// <summary>
///
/// </summary>
/// <typeparam name="T"></typeparam>
public class QueryologyEngineBuilder<T> : IQueryologyEngineBuilder<T>
    where T : DbContext
{
    private IQueryologyEngine<T>? _queryologyEngine;

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public QueryologyEngineOptions<T> Options { get; }

    /// <summary>
    /// 
    /// </summary>
    public QueryologyEngineBuilder()
    {
        Options = new QueryologyEngineOptions<T>();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="queryologyEngineOptions"></param>
    /// <returns></returns>
    public IQueryologyEngineBuilder<T> Configure(
        Action<QueryologyEngineOptions<T>> queryologyEngineOptions)
    {
        ArgumentNullException.ThrowIfNull(queryologyEngineOptions, nameof(queryologyEngineOptions));

        queryologyEngineOptions(Options);
        Options.QueryFactoryProvider ??= new QueryFactory<T>();
        Options.ObjectDisplayerProvider ??= NullObjectDisplayer.DisplayData;
        _queryologyEngine = new QueryologyEngine<T>(Options);

        return this;
    }

    /// <summary>
    /// Build a Queryology Engine.
    /// </summary>
    /// <returns>QueryologyEngine</returns>
    public IQueryologyEngine<T> Build()
    {
        ArgumentNullException.ThrowIfNull(_queryologyEngine, nameof(_queryologyEngine));

        return _queryologyEngine;
    }
}
