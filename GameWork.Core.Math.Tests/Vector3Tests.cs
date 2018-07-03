using GameWork.Core.Math.Types;
using Xunit;

namespace GameWork.Core.Math.Tests
{
    public class Vector3Tests
    {
        [Fact]
        public void CanAdd()
        {
            // Arrange
            var a = new Vector3(1, 2, 3);
            var b = new Vector3(4, 5, 6);
            var expected = new Vector3(5, 7, 9);

            // Act
            var result = a + b;

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanSubtract()
        {
            // Arrange
            var a = new Vector3(1, 2, 3);
            var b = new Vector3(4, 5, 6);
            var expected = new Vector3(-3, -3, -3);

            // Act
            var result = a - b;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
