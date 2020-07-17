using System;
using ByteDecoder.Queryology.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology
{
  public class QueryologyEngineOptions<T> where T : DbContext
  {
    public T DataContextProvider { get; set; }
    public IObjectDisplayer ObjectDisplayerProvider { get; set; }
  }

  public class QueryologyEngineBuilder<T> : IQueryologyEngineBuilder<T> where T : DbContext
  {
    private IQueryologyEngine<T> _queryologyEngine;

    public IQueryologyEngineBuilder<T> Configure(Action<QueryologyEngineOptions<T>> queryologyEngineOptions)
    {
      var options = new QueryologyEngineOptions<T>();
      queryologyEngineOptions(options);
      _queryologyEngine = new QueryologyEngine<T>(options.DataContextProvider, options.ObjectDisplayerProvider);

      return this;
    }

    public IQueryologyEngine<T> Build()
    {
      return _queryologyEngine;
    }
  }
}
