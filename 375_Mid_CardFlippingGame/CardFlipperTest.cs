using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace _375_Mid_CardFlippingGame
{
    public class CardFlipperTest
    {
        public static IEnumerable<object[]> GameTestCases => new List<object[]>()
        {
            new object[] { "0100110", new int[] { 1, 0, 2, 3, 5, 4, 6 } }
        };

        [Theory]
        [MemberData(nameof(GameTestCases))]
        public void TestSolve(string gameState, int[] expected)
        {
            var actual = new CardFlipper().Solve(gameState);
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
