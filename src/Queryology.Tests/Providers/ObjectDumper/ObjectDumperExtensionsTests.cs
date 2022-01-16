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
        public void AddObjectDumper_ReturnsIQueryologyEngineBuilder_WhenHasCorrectInputParams()
        {
            // Arrange
            using var dbContext = new InMemoryDbContext();
            var sut = new QueryologyEngineBuilder<InMemoryDbContext>()
                .Configure(options => options.DataContextProvider = dbContext);

            // Act
            sut.AddObjectDumper();

            // Assert
            Assert.NotNull(sut);
            Assert.IsType<QueryologyEngine<InMemoryDbContext>>(sut.Build());
        }
    }
}
