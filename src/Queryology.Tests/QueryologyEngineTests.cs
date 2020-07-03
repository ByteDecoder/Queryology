using ByteDecoder.Queryology;
using Queryology.Tests.Data;
using Xunit;

namespace Queryology.Tests
{
  public class QueryologyEngineTests
  {
    [Fact]
    public void Execute_RunOnlyEnabledRulesTypeA_WhenSomeAreDiseabled()
    {
      //  Arrange
      using var dbContext = new NullDbContext();
      var sut = new QueryologyEngine<NullDbContext>(dbContext);

      // Act
      var result = sut.Execute();

      // Asset
      Assert.Equal(2, result);
    }

    [Fact]
    public void Execute_RunOnlyEnabledRulesTypeB_WhenSomeAreDiseabled()
    {
      //  Arrange
      using var dbContext = new InMemoryDbContext();
      var sut = new QueryologyEngine<InMemoryDbContext>(dbContext);

      // Act
      var result = sut.Execute();

      // Asset
      Assert.Equal(1, result);
    }
  }
}