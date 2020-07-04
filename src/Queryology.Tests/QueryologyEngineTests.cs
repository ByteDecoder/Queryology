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

    public QueryologyEngineTests()
    {
      _testBuilderFactory = new TestBuilderFactory();
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
        // Dispose manage resources
      }

      _testBuilderFactory = null;
      _disposedValue = true;
    }

    public void Dispose()
    {
      Dispose(disposing: true);
      GC.SuppressFinalize(this);
    }
  }
}