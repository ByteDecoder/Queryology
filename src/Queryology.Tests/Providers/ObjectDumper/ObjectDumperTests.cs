using ByteDecoder.Queryology.Tests.Providers.Dummies;
using Xunit;

namespace ByteDecoder.Queryology.Tests.Providers.ObjectDumper
{
  public class ObjectDumperTests
  {
    private readonly DataStorage _dataStorage;

    public ObjectDumperTests()
    {
      _dataStorage = new DataStorage();
    }

    [Fact]
    public void Write_DumpData_WhenObjectIsPassed()
    {
      // Arrange    

      // Act
      var exception = Record.Exception(() =>
      {
        Queryology.Providers.ObjectDumper.ObjectDumper.Write(_dataStorage.Materials);
      });

      // Assert
      Assert.Null(exception);
    }
  }
}