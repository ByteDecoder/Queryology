using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.RoyalLibrary;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class QueryologyEngine<T> where T : DbContext
  {
    private readonly T _dataContext;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContext"></param>
    public QueryologyEngine(T dataContext)
    {
      _dataContext = dataContext;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Execute()
    {
      CreateQuery().ForEach(query => query.Execute());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerable<IQuery<T>> CreateQuery()
    {
      var loadedTypes = GetLoadedTypes(typeof(IQuery<T>));

      foreach (var type in loadedTypes)
      {
        yield return (IQuery<T>)Activator.CreateInstance(type, _dataContext);
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetType"></param>
    /// <returns></returns>
    private IEnumerable<Type> GetLoadedTypes(Type targetType)
    {
      return AppDomain.CurrentDomain.GetAssemblies()
         .SelectMany(assembly => assembly.GetTypes())
         .Where(type => targetType.IsAssignableFrom(type));
    }
  }
}
