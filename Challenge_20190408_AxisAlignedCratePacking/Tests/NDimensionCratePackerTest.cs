using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using hnyhny.AxisAlignedCratePacking.Packers;
using Xunit;

namespace hnyhny.AxisAlignedCratePacking.Tests
{
    public class NDimensionCratePackerTest
    {

        [Fact]
        public void TestFit()
        {
            var input = new List<uint[]>()
            {
                new uint[]{180598, 125683, 146932, 158296, 171997, 204683, 193694, 216231, 177673, 169317, 216456, 220003, 165939, 205613, 152779, 177216, 128838, 126894, 210076, 148407},
                new uint[]{1984, 2122, 1760, 2059, 1278, 2017, 1443, 2223, 2169, 1502, 1274, 1740, 1740, 1768, 1295, 1916, 2249, 2036, 1886, 2010}
            };

            var expected = BigInteger.Parse("4281855455197643306306491981973422080000");
            var actual = new NDimensionCratePacker().Fit(input);

            Assert.Equal(expected, actual);
        }
        [Theory]
        [MemberData(nameof(ThreeDimensionsTestData))]
        public void TestFitThreeDimensions(IEnumerable<uint> input, uint expected)
        {
            var inputArrays = new List<IEnumerable<uint>>(){
                input.Take(3),
                input.Skip(3)
            };
            var actual = new NDimensionCratePacker().Fit(inputArrays);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ThreeDimensionsTestData => Data.ThreeDimensional.TestCases;

        [Theory]
        [MemberData(nameof(TwoDimensionsTestData))]
        public void TestFitTwoDimensions(uint[] input, uint expected)
        {
            var inputArrays = new List<IEnumerable<uint>>(){
                input.Take(2),
                input.Skip(2)
            };
            var actual = new NDimensionCratePacker().Fit(inputArrays);

            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> TwoDimensionsTestData => new[] {
            new object[]{new uint[]{25, 18, 6, 5}, 15},
            new object[]{new uint[]{10, 10, 1, 1}, 100},
            new object[]{new uint[]{12, 34, 5, 6}, 12},
            new object[]{new uint[]{12345, 678910, 1112, 1314}, 5676},
            new object[]{new uint[]{5, 100, 6, 1}, 80},
            new object[]{new uint[]{5, 5, 3, 2}, 2},
            new object[]{new uint[]{5, 5, 6, 1}, 0}
        };
    }
    internal static class Data
    {
        internal static class ThreeDimensional
        {
            private static TestCase TestCase1 = new TestCase(new uint[] { 10, 10, 10, 1, 1, 1 }, 1000);
            private static TestCase TestCase2 = new TestCase(new uint[] { 12, 34, 56, 7, 8, 9 }, 32);
            private static TestCase TestCase3 = new TestCase(new uint[] { 123, 456, 789, 10, 11, 12 }, 32604);
            private static TestCase TestCase4 = new TestCase(new uint[] { 1234567, 89101112, 13141516, 171819, 202122, 232425 }, 174648);

            internal static IEnumerable<object[]> TestCases => new[]
        {
            CreateTestRunData(Data.ThreeDimensional.TestCase1),
            CreateTestRunData(Data.ThreeDimensional.TestCase2),
            CreateTestRunData(Data.ThreeDimensional.TestCase3),
            CreateTestRunData(Data.ThreeDimensional.TestCase4),
        };

            private static object[] CreateTestRunData(Data.TestCase TestCase)
            {
                return new object[]
                {
                TestCase.Dimensions,
                TestCase.Expected
                };
            }
        }
        private class TestCase
        {
            internal readonly uint[] Dimensions;
            internal readonly int Expected;
            public TestCase(uint[] dimensions, int expected)
            {
                this.Dimensions = dimensions;
                this.Expected = expected;
            }
        }
    }
}