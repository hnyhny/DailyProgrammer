using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using hnyhny.Extensions;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal class CratePacker
    {
        internal BigInteger Fit(IEnumerable<IEnumerable<uint>> input)
        {
            var crateDimensions = input.First();
            var boxDimensions = input.Skip(1).First();

            return CalculateFit(crateDimensions, boxDimensions);
        }

        internal BigInteger FitOptimized(IEnumerable<IEnumerable<uint>> input)
        {
            var crateDimensions = input.First();
            var boxPermutations = input.Skip(1).First().GetPermutations();

            return boxPermutations.Select(box => CalculateFit(crateDimensions, box)).Max();
        }

        internal BigInteger CalculateFit(IEnumerable<uint> crate, IEnumerable<uint> box)
        {
            return crate.Zip(box, (x, y) => x / y).Aggregate((first, second) => first * second);
        }
    }
}