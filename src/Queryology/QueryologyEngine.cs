using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.RoyalLibrary;
using Microsoft.EntityFrameworkCore;
using Queryology.Extensions;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// QueryologyEngine will look for all query objects loaded in the Current AppDomain with the type IQuery.
  /// </summary>
  /// <typeparam name="T">An Entity Framework DbContext derived class</typeparam>
  public class QueryologyEngine<T> : IQueryologyEngine where T : DbContext
  {
    private readonly T _dataContext;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContext">An Entity Framework DbContext class</param>
    public QueryologyEngine(T dataContext) => _dataContext = dataContext;

    /// <summary>
    /// Execute each query object IQuery, loaded in the Current AppDomain
    /// </summary>
    /// <param name="ignoreExcludedQueries">The default is true, otherwise all queries will executed even if they are mark as not executable</param>
    /// <returns>Total executed queries</returns>
    public int Execute(bool ignoreExcludedQueries = true)
    {
      var totalExecQueries = 0;

      RegisteredQueries()
        .AllowedQueries(ignoreExcludedQueries)
        .ForEach(query =>
        {
          query.Execute();
          checked { totalExecQueries++; }
        });

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
        .Where(type => targetType.IsAssignableFrom(type));

  }
}
