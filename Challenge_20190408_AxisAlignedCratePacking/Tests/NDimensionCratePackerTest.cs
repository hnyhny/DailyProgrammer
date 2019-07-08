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
            var actual = new NDimensionCratePacker(input).Fit();

            Assert.Equal(expected, actual);
        }
         [Theory]
        [MemberData(nameof(ThreeDimensionsTestData))]
        public void TestFitThreeDimensions(uint[] input, uint expected)
        {
            var inputArrays = new List<IEnumerable<uint>>(){
                input.Take(3),
                input.Skip(3)
            };
            var actual = new NDimensionCratePacker(inputArrays).Fit();
            
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ThreeDimensionsTestData => new[] {
            new object[]{new uint[]{10, 10, 10, 1, 1, 1}, 1000},
            new object[]{new uint[]{12, 34, 56, 7, 8, 9}, 32},
            new object[]{new uint[]{123, 456, 789, 10, 11, 12}, 32604},
            new object[]{new uint[]{1234567, 89101112, 13141516, 171819, 202122, 232425}, 174648},
        };

        [Theory]
        [MemberData(nameof(TwoDimensionsTestData))]
        public void TestFitTwoDimensions(uint[] input, uint expected)
        {
             var inputArrays = new List<IEnumerable<uint>>(){
                input.Take(2),
                input.Skip(2)
            };
            var actual = new NDimensionCratePacker(inputArrays).Fit();
            
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
}