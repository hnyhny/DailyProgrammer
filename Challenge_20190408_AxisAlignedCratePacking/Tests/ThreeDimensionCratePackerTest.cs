using System.Collections.Generic;
using hnyhny.AxisAlignedCratePacking.Packers;
using Xunit;

namespace hnyhny.AxisAlignedCratePacking.Tests
{
    public class ThreeDimensionCratePackerTest
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestFit(uint[] input, uint expected)
        {
            var actual = new ThreeDimensionCratePacker(input).Fit();
            
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> TestData => new[] {
            new object[]{new uint[]{10, 10, 10, 1, 1, 1}, 1000},
            new object[]{new uint[]{12, 34, 56, 7, 8, 9}, 32},
            new object[]{new uint[]{123, 456, 789, 10, 11, 12}, 32604},
            new object[]{new uint[]{1234567, 89101112, 13141516, 171819, 202122, 232425}, 174648},
        };
    }
}