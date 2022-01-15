using ByteDecoder.Queryology.Providers;
using Xunit;

namespace ByteDecoder.Queryology.Tests.Providers
{
    public class NullObjectDisplayerTest
    {
        [Fact]
        public void Getting_Always_Same_Object_Instance()
        {
            // Assert
            // Act
            var obj1 = NullObjectDisplayer.DisplayData;
            var obj2 = NullObjectDisplayer.DisplayData;

            // Assert
            Assert.Same(obj1, obj2);
        }

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
