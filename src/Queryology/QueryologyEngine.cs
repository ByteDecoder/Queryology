using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.Queryology.Extensions;
using ByteDecoder.RoyalLibrary;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// QueryologyEngine will look for all query objects loaded in the Current AppDomain with the type IQuery.
  /// </summary>
  /// <typeparam name="T">An Entity Framework DbContext derived class</typeparam>
  public class QueryologyEngine<T> : IQueryologyEngine<T> where T : DbContext
  {
    private readonly T _dataContext;
    private bool _ignoreExcludedQueries;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContext">An Entity Framework DbContext class</param>
    public QueryologyEngine(T dataContext)
    {
      _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
      _ignoreExcludedQueries = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ignoreQueries">The default is true, otherwise all queries will executed even if they are mark as not executable</param>
    /// <returns></returns>
    public IQueryologyEngine<T> IgnoreExcludedQueries(bool ignoreQueries = true)
    {
      _ignoreExcludedQueries = ignoreQueries;
      return this;
    }

    /// <summary>
    /// Execute each query object IQuery, loaded in the Current AppDomain
    /// </summary>
    /// <returns>Total executed queries</returns>
    public int Execute()
    {
      var totalExecQueries = 0;

      RegisteredQueries()
        .IgnoreExcludedQueries(_ignoreExcludedQueries)
        .ForEach(query =>
        {
          query.Execute();
          checked { totalExecQueries++; }
        });

      _ignoreExcludedQueries = true;
      return totalExecQueries;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>An enumerator for each of the Query Types registered in the loaded assemblies</returns>
    private IEnumerable<IQuery<T>> RegisteredQueries()
    {
      var loadedTypes = GetLoadedTypes(typeof(IQuery<T>));

      foreach (var type in loadedTypes)
      {
        yield return (IQuery<T>)Activator.CreateInstance(type, _dataContext);
      }
    }

    /// <summary>
    /// From the loaded Assembly, finds the types assignable to the targetType
    /// </summary>
    /// <param name="targetType">Target Type to find</param>
    /// <returns></returns>
    private IEnumerable<Type> GetLoadedTypes(Type targetType) =>
      AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(assembly => assembly.GetTypes())
        .Where(targetType.IsAssignableFrom);

  }
}
