using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.TestBuilders
{
  internal class QueryologyEngineTestBuilder<T> where T : DbContext
  {
    private readonly QueryologyEngine<T> _queryologyEngine;

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
  }
}