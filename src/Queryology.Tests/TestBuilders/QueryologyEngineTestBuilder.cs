using System;
using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.TestBuilders
{
  internal class QueryologyEngineTestBuilder<T> : IDisposable where T : DbContext
  {
    private readonly QueryologyEngine<T> _queryologyEngine;
    private bool disposedValue;

    public QueryologyEngineTestBuilder(T dbContext)
    {
      _queryologyEngine = new QueryologyEngine<T>(dbContext);
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
      if (!disposedValue)
      {
        if (disposing)
        {
          // TODO: eliminar el estado administrado (objetos administrados)
        }

        // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
        // TODO: establecer los campos grandes como NULL
        disposedValue = true;
      }
    }

    // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
    // ~QueryologyEngineTestBuilder()
    // {
    //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
      // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}