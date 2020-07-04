using System;
using System.Collections.Generic;
using System.Linq;
using ByteDecoder.Queryology;
using ByteDecoder.Queryology.Extensions;
using ByteDecoder.Queryology.Tests.Queries;
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
      using var dbContext = new NullDbContext();
      var queries = new List<IQuery<NullDbContext>>()
      {
        new QueryTypeNullDbContextOne(dbContext),
        new QueryTypeNullDbContextTwo(dbContext),
        new QueryTypeNullDbContextThree(dbContext)
      };

      // Act
      var result = queries.IgnoreExcludedQueries().Count();

      // Assert
      Assert.Equal(2, result);
    }


  }
}