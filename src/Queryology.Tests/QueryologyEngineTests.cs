using ByteDecoder.Queryology;
using Xunit;

namespace Queryology.Tests
{
  public class QueryologyEngineTests
  {
    [Fact]
    public void Execute_RunOnlyEnabledRules_WhenSomeAreDiseabled()
    {
      //  Arrange
      using var dbContext = new NullDbContext();
      var sut = new QueryologyEngine<NullDbContext>(dbContext);

      // Act
      var result = sut.Execute();

      // Asset
      Assert.Equal(2, result);
    }    
  }
}