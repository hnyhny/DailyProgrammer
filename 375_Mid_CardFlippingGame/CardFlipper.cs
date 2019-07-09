using System.Collections.Generic;
using System.Linq;
using System;
using hnyhny.Extensions;

namespace _375_Mid_CardFlippingGame
{
    internal class CardFlipper
    {
        internal int[] Solve(string game)
        {
            throw new NotImplementedException();
        }

        internal Dictionary<int, char[]> GetChildProblems(char[] state)
        {
            var result = new Dictionary<int, char[]>();
            for (int index = 0; index < state.Length; index++) 
            {
                if(state[index] == '1')
                    result.Add(index, FlipCards(state, index));
            }
            return result;
        }
        internal char[] FlipCards(char[] state, int card)
        {
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

