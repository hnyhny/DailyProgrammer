using System.Collections.Generic;
using hnyhny.AxisAlignedCratePacking.Packers;
using Xunit;

namespace hnyhny.AxisAlignedCratePacking.Tests
{
    public class CrateRotatingCratePackerTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestFit(uint[] input, uint expected)
        {
            var actual = new CrateRotatingCratePacker(input).Fit();

            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> TestData => new[] {
            new object[]{new uint[]{25, 18, 6, 5}, 15},
            new object[]{new uint[]{10, 10, 1, 1}, 100},
            new object[]{new uint[]{12, 34, 5, 6}, 12},
            new object[]{new uint[]{12345, 678910, 1112, 1314}, 5676},
            new object[]{new uint[]{5, 100, 6, 1}, 80},
            new object[]{new uint[]{5, 5, 3, 2}, 2},
            new object[]{new uint[]{5, 5, 6, 1}, 0}
        };
    }
}
