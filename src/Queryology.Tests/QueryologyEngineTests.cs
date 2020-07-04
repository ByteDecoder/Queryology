using ByteDecoder.Queryology.Tests.Data;
using Xunit;

namespace ByteDecoder.Queryology.Tests
{
  public class QueryologyEngineTests
  {
    [Fact]
    public void Execute_RunOnlyEnabledQueriesTypeA_WhenSomeAreDisabled()
    {
      //  Arrange
      using var dbContext = new NullDbContext();
      var sut = new QueryologyEngine<NullDbContext>(dbContext);

      // Act
      var result = sut.Execute();

      // Assert
      Assert.Equal(2, result);
    }

    [Fact]
    public void Execute_RunAllQueriesTypeA_WhenExecuteOverridesTheIgnoredQueries()
    {
      //  Arrange
      using var dbContext = new NullDbContext();
      var sut = new QueryologyEngine<NullDbContext>(dbContext);

      // Act
      var result = sut.Execute(false);

      // Assert
      Assert.Equal(3, result);
    }

    [Fact]
    public void Execute_RunOnlyEnabledQueriesTypeB_WhenSomeAreDisabled()
    {
      //  Arrange
      using var dbContext = new InMemoryDbContext();
      var sut = new QueryologyEngine<InMemoryDbContext>(dbContext);

      // Act
      var result = sut.Execute();

      // Assert
      Assert.Equal(1, result);
    }

    [Fact]
    public void Execute_AllQueriesTypeB_WhenExecuteOverridesTheIgnoredQueries()
    {
      //  Arrange
      using var dbContext = new InMemoryDbContext();
      var sut = new QueryologyEngine<InMemoryDbContext>(dbContext);

      // Act
      var result = sut.Execute(false);

      // Assert
      Assert.Equal(2, result);
    }

    [Fact]
    public void Execute_AllQueriesTypeC_WhenIsCalled()
    {
      //  Arrange
      using var dbContext = new ForeverAloneDbContext();
      var sut = new QueryologyEngine<ForeverAloneDbContext>(dbContext);

      // Act
      var result = sut.Execute(false);

      // Assert
      Assert.Equal(0, result);
    }
  }
}