using System;
using ByteDecoder.Queryology.Abstractions;
using ByteDecoder.Queryology.Providers.ObjectDumper;
using ByteDecoder.Queryology.Tests.Data;
using Xunit;

namespace ByteDecoder.Queryology.Tests.Providers.ObjectDumper
{
    public class ObjectDumperExtensionsTests
    {
        [Fact]
        public void AddObjectDumper_ThrowsArgumentNullException_WhenSourceInputIsNull()
        {
            // Arrange
            // Act
            var exception = Record.Exception(() =>
            {
                ((IQueryologyEngineBuilder<InMemoryDbContext>)null).AddObjectDumper();
            });

            // Assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void AddObjectDumper_ThrowsArgumentNullException_WhenDbContextInputIsNull()
        {
            // Arrange
            var engineBuilder = new QueryologyEngineBuilder<InMemoryDbContext>();

            // Act
            var exception = Record.Exception(() => engineBuilder.AddObjectDumper());

            // Assert
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void AddObjectDumper_ReturnsIQueryologyEngineBuilder_WhenHasCorrectInputParams()
        {
            // Arrange
            var sut = new QueryologyEngineBuilder<InMemoryDbContext>();
            using var dbContext = new InMemoryDbContext();

            // Act
            sut.AddObjectDumper();

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<QueryologyEngine<InMemoryDbContext>>(sut.Build());
        }
    }
}
