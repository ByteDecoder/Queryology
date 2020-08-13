using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Extensions;
using ByteDecoder.Queryology.Tests.TestBuilders;
using Xunit;

namespace ByteDecoder.Queryology.Tests
{
  public class QueryBaseExtensionsTests : IDisposable
  {
    private TestBuilderFactory _testBuilderFactory;
    private bool _disposedValue;

    public QueryBaseExtensionsTests()
    {
      _testBuilderFactory = new TestBuilderFactory();
    }

    [Fact]
    public void IgnoreExcludedQueries_ThrowsAnArgumentNullException_WhenSourceIsNull()
    {
      // Arrange
      IEnumerable<IQuery<NullDbContext>> queries = null;

      // Act
      // Assert
      Assert.Throws<ArgumentNullException>(() => queries.IgnoreExcludedQueries());
    }

    [Fact]
    public void IgnoreExcludedQueries_FiltersOnlyAllowedQueries_WhenIsSetToTrue()
    {
      // Arrange
      using var dbContext = new NullDbContext();
      var queries = _testBuilderFactory.CreateNullDbContextObjectQueries(dbContext);

      // Act
      var result = queries.IgnoreExcludedQueries().Count();

      // Assert
      Assert.Equal(2, result);
    }

    [Fact]
    public void IgnoreExcludedQueries_NoFiltersQueries_WhenIsSetToFalse()
    {
      // Arrange
      using var dbContext = new NullDbContext();
      var queries = _testBuilderFactory.CreateNullDbContextObjectQueries(dbContext);

      // Act
      var result = queries.IgnoreExcludedQueries(false).Count();

      // Assert
      Assert.Equal(3, result);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (_disposedValue)
        return;

      if (disposing)
      {
        // Dispose managed resources
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
