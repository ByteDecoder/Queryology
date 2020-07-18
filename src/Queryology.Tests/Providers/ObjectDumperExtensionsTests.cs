using System;
using ByteDecoder.Queryology;
using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Providers.ObjectDumper;
using ByteDecoder.Queryology.Tests.Data;
using Xunit;

namespace Queryology.Tests.Providers
{
  public class ObjectDumperExtensionsTests
  {
    [Fact]
    public void AddObjectDumper_ThrowsArgumentNullException_WhenSourceInputIsNull()
    {
      // Arrange
      IQueryologyEngineBuilder<InMemoryDbContext> engineBuilder = null;

      // Act
      var exception = Record.Exception(() => engineBuilder.AddObjectDumper(null));

      // Assert
      Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void AddObjectDumper_ThrowsArgumentNullException_WhenDbContextInputIsNull()
    {
      // Arrange
      var engineBuilder = new QueryologyEngineBuilder<InMemoryDbContext>();

      // Act
      var exception = Record.Exception(() => engineBuilder.AddObjectDumper(null));

      // Assert
      Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void AddObjectDumper_ReturnsIQueryologyEngineBuilder_WhenHasCorrectInputParams()
    {
      // Arrange

      // Act

      // Assert
    }
  }
}