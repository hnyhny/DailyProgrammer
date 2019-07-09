using System.Collections.Generic;
using System.Linq;
using System;
using hnyhny.Extensions;

namespace _375_Mid_CardFlippingGame
{
    internal class CardFlipper
    {
        private List<int> NoSolution = new List<int>();
        internal IEnumerable<int> Solve(string gameState)
        {
            var appendCardAtEnd = false;
            var result = new List<int>();

            gameState.Each((item, index) =>
            {
                if (appendCardAtEnd)
                    result.Add(index);
                else
                    result.Insert(0, index);

                appendCardAtEnd ^= (item == '1');
            });

            if(!appendCardAtEnd)
                return NoSolution;

            return result;
        }
    }
}

