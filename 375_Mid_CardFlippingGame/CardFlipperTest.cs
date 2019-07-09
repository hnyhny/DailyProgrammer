using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace _375_Mid_CardFlippingGame
{
    public class CardFlipperTest
    {
        public static IEnumerable<object[]> TestSolveData => new List<object[]>()
        {
            new object[] { "0100110", new int[] { 5, 1, 0, 2, 3, 4, 6 } },
            new object[] {"001011011101001001000", new int[] {17, 16, 15, 11, 10, 8, 5, 2, 1, 0, 3, 4, 6, 7, 9, 12, 13, 14, 18, 19, 20}},
            new object[] {"1010010101001011011001011101111", new int[] {}},
            new object[] {"1101110110000001010111011100110", new int[] {29, 25, 23, 22, 20, 17, 16, 8, 5, 3, 2, 0, 1, 4, 6, 7, 9, 10, 11, 12, 13, 14, 15, 18, 19, 21, 24, 26, 27, 28, 30}},
            new object[] {"010111111111100100101000100110111000101111001001011011000011000",
             new int[] {59, 53, 50, 47, 46, 45, 41, 39, 36, 35, 34, 33, 31, 28, 24, 23, 22, 21, 18, 17, 16, 12, 10, 8, 6, 4, 1, 0, 2, 3, 5, 7, 9, 11, 13, 14, 15, 19, 20, 25, 26, 27, 29, 30, 32, 37, 38, 40, 42, 43, 44, 48, 49, 51, 52, 54, 55, 56, 57, 58, 60, 61, 62}},
        };
        [Theory]
        [MemberData(nameof(TestSolveData))]
        public void TestSolve(string gameState, int[] expected)
        {
            var actual = new CardFlipper().Solve(gameState);
            Assert.Equal(expected, actual);
        }
    }
}
