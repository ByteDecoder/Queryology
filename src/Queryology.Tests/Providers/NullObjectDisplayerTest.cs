using ByteDecoder.Queryology.Providers;
using Xunit;

namespace ByteDecoder.Queryology.Tests.Providers
{
    public class NullObjectDisplayerTest
    {
        [Fact]
        public void DisplayData_DotNotThrowAnyException_WhenIsCalled()
        {
            // Assert
            var displayer = NullObjectDisplayer.DisplayData;

            // Act
            var exception = Record.Exception(() => displayer("", null, 0));

            // Assert
            Assert.Null(exception);
        }
    }
}
