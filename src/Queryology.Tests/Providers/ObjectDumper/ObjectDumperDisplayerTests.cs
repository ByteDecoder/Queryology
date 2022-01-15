using System;
using System.Collections;
using ByteDecoder.Queryology.Providers.ObjectDumper;
using ByteDecoder.Queryology.Tests.Providers.Dummies;
using Xunit;

namespace ByteDecoder.Queryology.Tests.Providers.ObjectDumper
{
    public class ObjectDumperDisplayerTests
    {
        private readonly DataStorage _dataStorage;

        public ObjectDumperDisplayerTests()
        {
            _dataStorage = new DataStorage();
        }

        [Fact]
        public void DisplayData_DoNotThrowsExceptions_WhenIsCalled()
        {
            // Arrange
            var sut = ObjectDumperDisplayer.DisplayData;
            var data = new
            {
                Name = "Jane Louis",
                Age = 25,
                Date = DateTime.Now,
                Books = new ArrayList()
                {
                    new { Title = "Euridice", Price = 25.99, Friends = _dataStorage.Friends },
                    new { Title = "Euridice", Price = 25.99 },
                },
                Friends = _dataStorage.Friends,
                Magical = _dataStorage.Magical,
                Materials = _dataStorage.Materials,
                Misc = _dataStorage.Misc
            };

            // Act
            var exception = Record.Exception(() =>
            {
                sut("Testing", data, 3);
            });

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DisplayData_DoNotThrowsExceptions_WhenIsCalledWithNullData()
        {
            // Arrange
            var sut = ObjectDumperDisplayer.DisplayData;

            // Act
            var exception = Record.Exception(() =>
            {
                sut("Testing", null, 5);
            });

            // Assert
            Assert.Null(exception);
        }
    }
}
