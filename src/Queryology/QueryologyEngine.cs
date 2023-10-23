using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology;

/// <summary>
/// QueryologyEngine will look for all query objects loaded in the Current AppDomain with the type IQuery.
/// </summary>
/// <typeparam name="T">An Entity Framework DbContext derived class</typeparam>
public class QueryologyEngine<T> : IQueryologyEngine<T>
    where T : DbContext
{
    private readonly T _dataContext;
    private readonly IQueryFactory<T> _queryFactory;
    private readonly DisplayObjectData _objectDisplayer;
    private bool _ignoreExcludedQueries;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryologyEngine{T}"/> class.
    /// </summary>
    /// <param name="queryologyOptions">Expect and instance of instance of
    /// the <see cref="QueryologyEngineOptions{T}"/> class.</param>
    public QueryologyEngine(QueryologyEngineOptions<T> queryologyOptions)
    : this(
      queryologyOptions.DataContextProvider,
      queryologyOptions.QueryFactoryProvider,
      queryologyOptions.ObjectDisplayerProvider)
    { }

    /// <summary>
    ///
    /// </summary>
    /// <param name="dataContext"></param>
    /// <param name="queryFactory"></param>
    /// <param name="objectDisplayer"></param>
    public QueryologyEngine(
        T? dataContext,
        IQueryFactory<T>? queryFactory,
        DisplayObjectData? objectDisplayer)
    {
        _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        _queryFactory = queryFactory ?? throw new ArgumentNullException(nameof(queryFactory));
        _objectDisplayer = objectDisplayer ?? throw new ArgumentNullException(nameof(objectDisplayer));
        _ignoreExcludedQueries = true;
    }

    /// <summary>
    /// LINQ deferred query operator to filter the query execution if queries are
    /// Executable or ignore that object state.
    /// </summary>
    /// <param name="ignoreQueries">The default is true, otherwise all queries will executed even if they are mark as not executable</param>
    /// <returns>returns the IQueryologyEngine of type T instance.</returns>
    public IQueryologyEngine<T> IgnoreExcludedQueries(bool ignoreQueries)
    {
        _ignoreExcludedQueries = ignoreQueries;
        return this;
    }

    /// <summary>
    /// Execute each query object IQuery, loaded in the Current AppDomain.
    /// </summary>
    /// <returns>Total executed queries.</returns>
    public int Execute()
    {
        var totalExecQueries = 0;

        var queries = RegisteredQueries()
          .IgnoreExcludedQueries(_ignoreExcludedQueries);

        foreach (var query in queries)
        {
            query.Execute();
            checked
            { totalExecQueries++; }
        }

        _ignoreExcludedQueries = true;
        return totalExecQueries;
    }

    /// <summary>
    /// Scan the assembly for all types assignable to IQuery and create an instance of each.
    /// </summary>
    /// <returns>An enumerator for each of the Query Types registered in the loaded assemblies.</returns>
    private IEnumerable<IQuery<T>> RegisteredQueries()
    {
        var loadedTypes = GetLoadedTypes(typeof(IQuery<T>));

        foreach (var type in loadedTypes)
        {
            var query = _queryFactory.Create(type, new object[] { _dataContext, _objectDisplayer });

            yield return query;
        }
    }

    /// <summary>
    /// From the loaded Assembly, finds the types assignable to the targetType.
    /// </summary>
    /// <param name="targetType">Target Type to find.</param>
    /// <returns>IEnumerable of Type.</returns>
    private IEnumerable<Type> GetLoadedTypes(Type targetType) =>
      AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(targetType.IsAssignableFrom);

}
