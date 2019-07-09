using System.Collections.Generic;

namespace hnyhny.AxisAlignedCratePacking.Tests
{
    internal static class TestCases
    {
        internal static class Fit
        {
            public static IEnumerable<object[]> TwoDimensions => new[] 
            {
                new object[]{new uint[]{25, 18, 6, 5}, 12},
                new object[]{new uint[]{10, 10, 1, 1}, 100},
                new object[]{new uint[]{12, 34, 5, 6}, 10},
                new object[]{new uint[]{12345, 678910, 1112, 1314}, 5676},
                new object[]{new uint[]{5, 100, 6, 1}, 0}
            };
        }
        internal static class OptimizedFit
        {
            internal static IEnumerable<object[]> TwoDimensions => new[]
            {
                new object[]{new uint[]{25, 18, 6, 5}, 15},
                new object[]{new uint[]{10, 10, 1, 1}, 100},
                new object[]{new uint[]{12, 34, 5, 6}, 12},
                new object[]{new uint[]{12345, 678910, 1112, 1314}, 5676},
                new object[]{new uint[]{5, 100, 6, 1}, 80},
                new object[]{new uint[]{5, 5, 3, 2}, 2},
                new object[]{new uint[]{5, 5, 6, 1}, 0}
            };

            internal static IEnumerable<object[]> ThreeDimensions => new[]
            {
                new object[]{new uint[] { 10, 10, 10, 1, 1, 1 }, 1000},
                new object[] {new uint[] { 12, 34, 56, 7, 8, 9 }, 32},
                new object[] {new uint[] { 123, 456, 789, 10, 11, 12 }, 32604},
                new object[]{new uint[] { 1234567, 89101112, 13141516, 171819, 202122, 232425 }, 174648}    
            };
        }
    }
}