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
      var obj1 = NullObjectDisplayer.Instance;
      var obj2 = NullObjectDisplayer.Instance;

      // Assert
      Assert.Same(obj1, obj2);
    }

    [Fact]
    public void DisplayData_DotNotThrowAnyException_WhenIsCalled()
    {
      // Assert
      var displayer = NullObjectDisplayer.Instance;

      // Act
      var exception = Record.Exception(() => displayer.DisplayData("", null, 0));

      // Assert
      Assert.Null(exception);
    }
  }
}