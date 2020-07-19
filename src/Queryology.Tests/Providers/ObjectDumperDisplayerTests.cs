using System;
using System.Collections.Generic;
using ByteDecoder.Queryology.Providers.ObjectDumper;
using Xunit;

namespace Queryology.Tests.Providers
{
  public class ObjectDumperDisplayerTests
  {
    private readonly IEnumerable<string> _friends = new[] { "Jeremias", "Matias" };

    [Fact]
    public void DisplayData_DoNotThrowsExceptions_WhenIsCalled()
    {
      // Arrange
      var sut = new ObjectDumperDisplayer();
      var data = new
      {
        Name = "Jane Louis",
        Age = 25,
        Date = DateTime.Now.ToShortDateString(),
        Books = new[] {
          new { Title = "Euridice", Price = 25.99 },
          new { Title = "Euridice", Price = 25.99 },
        },
        Friends = _friends
      };

      // Act        
      var exception = Record.Exception(() =>
      {
        sut.DisplayData("Testing", data, 3);
      });

      // Assert
      Assert.Null(exception);
    }

    [Fact]
    public void DisplayData_DoNotThrowsExceptions_WhenIsCalledWithNullData()
    {
      // Arrange
      var sut = new ObjectDumperDisplayer();

      // Act        
      var exception = Record.Exception(() =>
      {
        sut.DisplayData("Testing", null, 5);
      });

      // Assert
      Assert.Null(exception);
    }
  }
}