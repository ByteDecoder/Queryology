using System;
using Xunit;

namespace ByteDecoder.Queryology.Tests
{
  public class DefaultObjectDisplayerTests
  {
    [Fact]
    public void DisplayData_ThrowExceptions_WhenDataIsNull()
    {
      // Arrange
      var sut = new DefaultObjectDisplayer();

      // Act
      var exception = Record.Exception(() => sut.DisplayData("Test", null, 1));

      // Assert
      Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void DisplayData_ExecutesOk_WhenHasCorrectParams()
    {
      // Arrange
      var sut = new DefaultObjectDisplayer();

      // Act
      var exception = Record.Exception(() => sut.DisplayData("Test", new { Id = 1 }, 1));

      // Assert
      Assert.Null(exception);
    }
  }
}
