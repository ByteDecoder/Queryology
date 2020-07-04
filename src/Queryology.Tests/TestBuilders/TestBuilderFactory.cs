using Microsoft.EntityFrameworkCore;

namespace ByteDecoder.Queryology.Tests.TestBuilders
{
  internal class TestBuilderFactory
  {
    public QueryologyEngineTestBuilder<T> Create<T>() where T : DbContext, new()
    {
      return new QueryologyEngineTestBuilder<T>();
    }
  }
}
