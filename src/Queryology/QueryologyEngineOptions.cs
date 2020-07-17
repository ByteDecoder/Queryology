using System;
using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class QueryologyEngineOptions<T> where T : DbContext
  {
    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public T DataContextProvider { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <value></value>
    public IObjectDisplayer ObjectDisplayerProvider { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public QueryologyEngineOptions() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataContextProvider"></param>
    /// <param name="objectDisplayer"></param>
    public QueryologyEngineOptions(T dataContextProvider, IObjectDisplayer objectDisplayer)
    {
      DataContextProvider = dataContextProvider ?? throw new ArgumentNullException(nameof(dataContextProvider));
      ObjectDisplayerProvider = objectDisplayer ?? throw new ArgumentNullException(nameof(objectDisplayer));
    }
  }
}