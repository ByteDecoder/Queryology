using ByteDecoder.Queryology.Providers.ObjectDumper;
using Queryology.Tests.Providers.Dummies;
using Xunit;

namespace Queryology.Tests.Providers
{
  public class ObjectDumperTests
  {
    private readonly DataStorage _dataSorage;

    public ObjectDumperTests()
    {
      _dataSorage = new DataStorage();
    }

    [Fact]
    public void Write_DumpData_WhenOnjectIsPassed()
    {
      // Arrange    

      // Act
      var exception = Record.Exception(() =>
      {
        ObjectDumper.Write(_dataSorage.Materials);
      });

      // Assert
      Assert.Null(exception);
    }
  }
}