using System.Collections.Generic;
using System.Linq;
using System;
using hnyhny.Extensions;

namespace _375_Mid_CardFlippingGame
{
    internal class CardFlipper
    {
        private const int NOT_FLIPPED = -1;

        internal int[] Solve(string game)
        {
            throw new NotImplementedException();
        }

        internal char[] FlipCards(char[] state, int card)
        {
            if (state[card] != '1')
                throw new NotSupportedException("Only a card with value '1' can be flipped.");

            char[] result = state.DeepCopy();
            result[card] = '.';

            var leftNeighbor = card - 1;
            if (leftNeighbor >= 0)
                result[leftNeighbor] = FlipCard(state[leftNeighbor]);

            var rightNeigbor = card + 1;
            if (rightNeigbor <= state.Length - 1)
                result[rightNeigbor] = FlipCard(state[rightNeigbor]);

            return result;
        }

        private char[] CopyState(char[] state)
        {
            var result = new char[state.Length];
            for (int index = 0; index < state.Length; index++)
            {
                result[index] = state[index];
            }

            return result;
        }

        private char FlipCard(char card)
        {
            if (card == '.')
                return '.';

            if (card == '1')
                return '0';

            return '1';
        }
    }
}

