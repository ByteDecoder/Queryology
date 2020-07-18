using System;
using ByteDecoder.Queryology.Tests.Data;
using ByteDecoder.Queryology.Tests.Queries;
using ByteDecoder.Queryology.Tests.Support;
using Xunit;

namespace ByteDecoder.Queryology.Tests
{
  public class QueryBaseTests
  {
    [Fact]
    public void Constructor_ThrowsArgumentNullException_WhenNullIsPassedAsDbContext()
    {
      // Arrange
      // Act
      var exception = Record.Exception(() => new QueryTypeInMemoryDbContextTwo(null, null));

      // Assert
      Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Constructor_ThrowsArgumentNullException_WhenNullIsPassedAsObjectViewer()
    {
      // Arrange
      using var dbContext = new InMemoryDbContext();

      // Act
      var exception = Record.Exception(() => new QueryTypeInMemoryDbContextTwo(dbContext, null));

      // Assert
      Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Constructor_CreatesObjectInstance_WhenHasValidParams()
    {
      // Arrange
      using var dbContext = new InMemoryDbContext();
      var objectViewer = new TestObjectViewer();

      // Act
      var sut = new QueryTypeInMemoryDbContextTwo(dbContext, objectViewer);

      // Assert
      Assert.NotNull(sut);
    }

    [Fact]
    public void ObjectDisplayer_IsNullByDefault_WhenObjectIsCreated()
    {
      // Arrange
      // Act
      var sut = new QueryTypeInMemoryDbContextTwo();

      // Assert
      Assert.Null(sut.ObjectDisplayer);
    }

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
