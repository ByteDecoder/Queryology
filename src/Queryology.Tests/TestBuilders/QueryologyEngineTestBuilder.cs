using System;
using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Tests.Support;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.TestBuilders
{
  internal class QueryologyEngineTestBuilder<T> : IDisposable
      where T : DbContext, new()
  {
    private T _dbContext;
    private IQueryologyEngine<T> _queryologyEngine;
    private bool _disposedValue;

    public QueryologyEngineTestBuilder()
    {
      _dbContext = new T();
      _queryologyEngine = new QueryologyEngineBuilder<T>().Configure(options =>
      {
        options.DataContextProvider = _dbContext;
        options.ObjectDisplayerProvider = new TestObjectViewer();
      }).Build();
    }

    public QueryologyEngineTestBuilder<T> NotIgnoreExcludedQueries()
    {
      _queryologyEngine.IgnoreExcludedQueries(false);
      return this;
    }

    public QueryologyEngineTestBuilder<T> IgnoreExcludedQueries()
    {
      _queryologyEngine.IgnoreExcludedQueries(true);
      return this;
    }

    public IQueryologyEngine<T> Build()
    {
      return _queryologyEngine;
    }

    protected virtual void Dispose(bool disposing)
    {
      if (_disposedValue)
        return;

      if (disposing)
      {
        _dbContext.Dispose();
      }

      _dbContext = null;
      _queryologyEngine = null;

      _disposedValue = true;
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}
