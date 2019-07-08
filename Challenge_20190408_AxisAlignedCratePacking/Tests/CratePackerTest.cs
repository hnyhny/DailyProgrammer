using System.Linq;
using System.Numerics;
using System.Collections.Generic;
using hnyhny.AxisAlignedCratePacking.Packers;
using Xunit;
using System;

namespace hnyhny.AxisAlignedCratePacking.Tests
{
    public class CratePackerTest
    {
        public static IEnumerable<object[]> FitTwoDimensionsData => TestCases.Fit.TwoDimensions;
        public static IEnumerable<object[]> OptimizedFitTwoDimensionsData => TestCases.OptimizedFit.TwoDimensions;
        public static IEnumerable<object[]> OptimizedFitThreeDimensionsData => TestCases.OptimizedFit.ThreeDimensions;

        [Fact]
        public void TestOptimizedFitTwentyDimensions()
        {
            var input = new List<uint[]>()
            {
                new uint[]{180598, 125683, 146932, 158296, 171997, 204683, 193694, 216231, 177673, 169317, 216456, 220003, 165939, 205613, 152779, 177216, 128838, 126894, 210076, 148407},
                new uint[]{1984, 2122, 1760, 2059, 1278, 2017, 1443, 2223, 2169, 1502, 1274, 1740, 1740, 1768, 1295, 1916, 2249, 2036, 1886, 2010}
            };

            var expected = BigInteger.Parse("4281855455197643306306491981973422080000");
            var actual = new CratePacker().FitOptimized(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(OptimizedFitThreeDimensionsData))]
        public void TestOptimizedFitThreeDimensions(IEnumerable<uint> input, uint expected)
        {
            var inputArrays = PrepareTestInput(input, 3);
            var actual = new CratePacker().FitOptimized(inputArrays);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(OptimizedFitTwoDimensionsData))]
        public void TestOptimizedFitTwoDimensions(uint[] input, uint expected)
        {
            var inputArrays = PrepareTestInput(input, 2);
            var actual = new CratePacker().FitOptimized(inputArrays);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(FitTwoDimensionsData))]
        public void TestFitTwoDimensions(uint[] input, uint expected)
        {
            var inputArrays = PrepareTestInput(input, 2);
            var actual = new CratePacker().Fit(inputArrays);

            Assert.Equal(expected, actual);
        }

        private IEnumerable<IEnumerable<uint>> PrepareTestInput(IEnumerable<uint> input, int dimensions)
        {
            return new List<IEnumerable<uint>>()
            {
                input.Take(dimensions),
                input.Skip(dimensions)
            };
        }
    }
}