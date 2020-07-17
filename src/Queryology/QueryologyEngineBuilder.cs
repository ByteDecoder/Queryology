using System;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  /// <summary>
  /// 
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public class QueryologyEngineBuilder<T> : IQueryologyEngineBuilder<T> where T : DbContext
  {
    private IQueryologyEngine<T> _queryologyEngine;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="queryologyEngineOptions"></param>
    /// <returns></returns>
    public IQueryologyEngineBuilder<T> Configure(Action<QueryologyEngineOptions<T>> queryologyEngineOptions)
    {
      var options = new QueryologyEngineOptions<T>();
      queryologyEngineOptions(options);
      _queryologyEngine = new QueryologyEngine<T>(options.DataContextProvider, options.ObjectDisplayerProvider);

      return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IQueryologyEngine<T> Build()
    {
      return _queryologyEngine;
    }
  }
}
