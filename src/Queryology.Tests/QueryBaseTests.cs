using System;
using ByteDecoder.Queryology.Tests.Data;
using ByteDecoder.Queryology.Tests.Queries;
using Xunit;

namespace ByteDecoder.Queryology.Tests
{
  public class QueryBaseTests
  {
    [Fact]
    public void Data_SetDataToNull_WhenNullWhenQueryObjectIsCreated()
    {
      // Arrange
      using var dbContext = new InMemoryDbContext();
      var query = new QueryTypeInMemoryDbContextTwo { DataContext = dbContext };

      // Act
      // Assert
      Assert.Null(query.Data);
    }

    [Fact]
    public void Data_HasValue_WhenIsProvided()
    {
      // Arrange
      using var dbContext = new InMemoryDbContext();
      var query = new QueryTypeInMemoryDbContextTwo { DataContext = dbContext };

      // Act
      query.Execute();

      // Assert
      Assert.NotNull(query.Data);
    }

    [Fact]
    public void DataContext_HasValue_WhenIsProvided()
    {
      // Arrange
      using var dbContext = new InMemoryDbContext();
      var query = new QueryTypeInMemoryDbContextTwo { DataContext = dbContext };

      // Act
      // Assert
      Assert.NotNull(query.DataContext);
    }
  }
}
