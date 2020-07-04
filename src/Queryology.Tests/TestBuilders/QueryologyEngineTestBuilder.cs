using System;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.TestBuilders
{
  internal class QueryologyEngineTestBuilder<T> : IDisposable where T : DbContext
  {
    private T _dbContext;
    private QueryologyEngine<T> _queryologyEngine;
    private bool _disposedValue;

    public QueryologyEngineTestBuilder(T dbContext)
    {
      _dbContext = dbContext;
      _queryologyEngine = new QueryologyEngine<T>(_dbContext);
    }

    public QueryologyEngineTestBuilder<T> NotIgnoreExcludedQueries()
    {
      _queryologyEngine.IgnoreExcludedQueries(false);
      return this;
    }

    public QueryologyEngineTestBuilder<T> IgnoreExcludedQueries()
    {
      _queryologyEngine.IgnoreExcludedQueries();
      return this;
    }

    public QueryologyEngine<T> Build()
    {
      return _queryologyEngine;
    }

    protected virtual void Dispose(bool disposing)
    {
      if (_disposedValue) return;

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