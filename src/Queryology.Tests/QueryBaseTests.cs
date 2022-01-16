using System;
using ByteDecoder.Queryology.Tests.Data;
using ByteDecoder.Queryology.Tests.Queries;
using ByteDecoder.Queryology.Tests.Support;
using Xunit;

namespace ByteDecoder.Queryology.Tests;

public class QueryBaseTests
{
    [Fact]
    public void Constructor_CreatesObjectInstance_WhenHasValidParams()
    {
        // Arrange
        using var dbContext = new InMemoryDbContext();

        // Act
        var sut = new QueryTypeInMemoryDbContextTwo(dbContext, TestObjectViewer.DisplayData);

        // Assert
        Assert.NotNull(sut);
    }

    [Fact]
    public void Execute_Run_QueryInstanceSuccessful()
    {
        // Arrange
        using var dbContext = new InMemoryDbContext();
        var query = new QueryTypeInMemoryDbContextTwo(dbContext, TestObjectViewer.DisplayData);

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
        var query = new QueryTypeInMemoryDbContextTwo(dbContext, TestObjectViewer.DisplayData);

        // Act
        // Assert
        Assert.NotNull(query.DataContext);
    }

    [Fact]
    public void Execute_ThrowsArgumentNullException_WhenDbContextIsNull()
    {
        // Arrange
        // Act
        var exception = Record.Exception(() =>
        {
            new QueryTypeInMemoryDbContextTwo(null, TestObjectViewer.DisplayData);
        });

        // Assert
        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Execute_ThrowsArgumentNullException_WhenDisplayerDeleagteIsNull()
    {
        // Arrange
        using var dbContext = new InMemoryDbContext();

        // Act
        var exception = Record.Exception(() => new QueryTypeInMemoryDbContextTwo(dbContext, null));

        // Assert
        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Constructor_ThrowsArgumentNullException_WhenDbContextAndDisplayerDeleagteIsNull()
    {
        // Arrange
        // Act
        var exception = Record.Exception(() => new QueryTypeInMemoryDbContextTwo(null, null));

        // Assert
        Assert.IsType<ArgumentNullException>(exception);
    }
}
