using System;
using System.Collections.Generic;
using ByteDecoder.Queryology;
using ByteDecoder.Queryology.Extensions;
using Xunit;

namespace Queryology.Tests
{
  public class QueryBaseExtensionsTests
  {
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

      // Act

      // Assert
    }
  }
}