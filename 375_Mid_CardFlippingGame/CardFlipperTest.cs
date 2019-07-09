using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace _375_Mid_CardFlippingGame
{
    public class CardFlipperTest
    {
        public static IEnumerable<object[]> TestSolveData => new List<object[]>()
        {
            new object[] { "0100110", new int[] { 1, 0, 2, 3, 5, 4, 6 } }
        };
        public static IEnumerable<object[]> TestGetChildProblemsData => new List<object[]>()
        {
            new object[] { "0000", new Dictionary<int, char[]>() },
            new object[] { "1010", new Dictionary<int, char[]>()
            {
                {0, ".110".ToArray()},
                {2, "11.1".ToArray()},
            } },
            new object[] { "111", new Dictionary<int, char[]>()
            {
                {0, ".01".ToArray()},
                {1, "0.0".ToArray()},
                {2, "10.".ToArray()},
            } },
        };
        [Theory]
        [MemberData(nameof(TestSolveData))]
        public void TestSolve(string gameState, int[] expected)
        {
            var actual = new CardFlipper().Solve(gameState);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [MemberData(nameof(TestGetChildProblemsData))]
        public void TestGetChildProblems(string gameState, Dictionary<int, char[]> expected)
        {
            var actual = new CardFlipper().GetChildProblems(gameState.ToArray());
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("111", 1, "0.0")]
        [InlineData("010", 1, "1.1")]
        [InlineData("100", 0, ".10")]
        [InlineData("001", 2, "01.")]
        public void FlipCards(string gameState, int card, string expected)
        {
            var actual = new CardFlipper().FlipCards(gameState.ToArray(), card);
            Assert.Equal(expected.ToArray(), actual);
        }
    }
}
