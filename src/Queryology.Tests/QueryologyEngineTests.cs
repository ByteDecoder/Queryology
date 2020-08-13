using System;
using ByteDecoder.Queryology.Tests.Data;
using ByteDecoder.Queryology.Tests.TestBuilders;
using Xunit;

namespace ByteDecoder.Queryology.Tests
{
  public class QueryologyEngineTests: IDisposable
  {
    private TestBuilderFactory _testBuilderFactory;
    private bool _disposedValue;
    private QueryFactory<InMemoryDbContext> _queryFactory;

    public QueryologyEngineTests()
    {
      _testBuilderFactory = new TestBuilderFactory();
      _queryFactory = new QueryFactory<InMemoryDbContext>();
    }

    [Fact]
    public void Instantiate_ThrowsArgumentNullException_WhenNullValueIsPassedAsDbObject()
    {
      // Arrange
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => new QueryologyEngine<InMemoryDbContext>(null, null, null));
    }

    [Fact]
    public void Instantiate_ThrowsArgumentNullException_WhenNullValueIsPassedAsQueryFactory()
    {
      // Arrange
      // Act
      var exception = Record.Exception(() =>
      {
        var dbContext = new InMemoryDbContext();
        var dummy = new QueryologyEngine<InMemoryDbContext>(dbContext, null, null);
      });

      // Assert
      Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Instantiate_ThrowsArgumentNullException_WhenNullValueIsPassedAsObjectDisplayer()
    {
      // Arrange
      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() =>
      {
        var dbContext = new InMemoryDbContext();
        return new QueryologyEngine<InMemoryDbContext>(dbContext, _queryFactory, null);
      });
    }

    [Fact]
    public void Execute_RunOnlyEnabledQueriesTypeNullDbContext_WhenSomeAreDisabled()
    {
      //  Arrange
      using var testBuilder = _testBuilderFactory.Create<NullDbContext>();
      var sut = testBuilder.Build();

      // Act
      var result = sut.Execute();

      // Assert
      Assert.Equal(2, result);
    }

    [Fact]
    public void Execute_RunAllQueriesTypeNullDbContext_WhenExecuteOverridesTheIgnoredQueries()
    {
      //  Arrange
      using var testBuilder = _testBuilderFactory.Create<NullDbContext>();
      var sut = testBuilder.NotIgnoreExcludedQueries().Build();

      // Act
      var result = sut.Execute();

      // Assert
      Assert.Equal(3, result);
    }

    [Fact]
    public void Execute_RunOnlyEnabledQueriesTypeInMemoryDbContext_WhenSomeAreDisabled()
    {
      //  Arrange
      using var testBuilder = _testBuilderFactory.Create<InMemoryDbContext>();
      var sut = testBuilder.Build();

      // Act
      var result = sut.Execute();

      // Assert
      Assert.Equal(1, result);
    }

    [Fact]
    public void Execute_AllQueriesTypeInMemoryDbContext_WhenExecuteOverridesTheIgnoredQueries()
    {
      //  Arrange
      using var testBuilder = _testBuilderFactory.Create<InMemoryDbContext>();
      var sut = testBuilder.NotIgnoreExcludedQueries().Build();

      // Act
      var result = sut.Execute();

      // Assert
      Assert.Equal(2, result);
    }

    [Fact]
    public void Execute_ResetToDefaultIgnoreExcludedQueriesTypeInMemoryDbContext_WhenIsExecutedAgain()
    {
      //  Arrange
      using var testBuilder = _testBuilderFactory.Create<InMemoryDbContext>();
      var sut = testBuilder.NotIgnoreExcludedQueries().Build();

      // Act
      var totalQueriesIteration1 = sut.Execute();
      var totalQueriesIteration2 = sut.Execute();

      // Assert
      Assert.Equal(2, totalQueriesIteration1);
      Assert.Equal(1, totalQueriesIteration2);
    }

    [Fact]
    public void Execute_AllQueriesTypeForeverAloneDbContext_WhenIsCalled()
    {
      //  Arrange
      using var testBuilder = _testBuilderFactory.Create<ForeverAloneDbContext>();
      var sut = testBuilder.NotIgnoreExcludedQueries().Build();

      // Act
      var result = sut.Execute();

      // Assert
      Assert.Equal(0, result);
    }

    protected virtual void Dispose(bool disposing)
    {
      if(_disposedValue) return;

      if(disposing)
      {
        // Dispose managed resources
      }

      _testBuilderFactory = null;
      _queryFactory = null;
      _disposedValue = true;
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}
