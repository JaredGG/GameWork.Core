using Xunit;

namespace GameWork.Core.Math.Tests
{
    public class MathFTests
    {
        [Theory]
        [InlineData(-11, 9, 0.5f, -1)]
        [InlineData(11, -9, 0.5f, 1)]
        [InlineData(2000, 1000, 0.2f, 1800)]
        [InlineData(1000, 2000, 0.2f, 1200)]
        [InlineData(-2000, -1000, 0.2f, -1800)]
        [InlineData(-1000, -2000, 0.2f, -1200)]
        [InlineData(10, -10, 4, -10)]
        [InlineData(10, -10, -5, 10)]
        public void CanLerp(float start, float end, float weight, float expected)
        { 
            // Act
            var result = MathF.Lerp(start, end, weight);

            // Assert
            Assert.Equal(expected, result);
        }

        [InlineData(2, 0, 1, 1)]
        [InlineData(-2, 0, 1, 0)]
        [InlineData(0.5f, 0, 1, 0.5f)]
        [InlineData(-300, -100, 100, -100)]
        [InlineData(300, -100, 100, 100)]
        [InlineData(-25, -100, 100, -25)]
        public void CanClamp(float val, float min, float max, float expected)
        {
            // Act
            var result = val.Clamp(min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [InlineData(100, 100)]
        [InlineData(-100, 100)]
        public void CanAbs(float val, float expected)
        {
            // Act
            var result = MathF.Abs(val);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
