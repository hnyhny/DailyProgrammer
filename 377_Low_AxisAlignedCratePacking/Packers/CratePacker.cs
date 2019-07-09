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
        internal BigInteger Fit(IEnumerable<uint> input)
        {
            var dimensions = input.Count() / 2;
            var crateDimensions = input.Take(dimensions);
            var boxDimensions = input.Skip(dimensions);

            return CalculateFit(crateDimensions, boxDimensions);
        }

        internal BigInteger FitOptimized(IEnumerable<uint> input)
        {
            var dimensions = input.Count() / 2;
            var crateDimensions = input.Take(dimensions);
            var boxPermutations = input.Skip(dimensions).GetPermutations();

            return boxPermutations.Select(box => CalculateFit(crateDimensions, box)).Max();
        }

        internal BigInteger CalculateFit(IEnumerable<uint> crate, IEnumerable<uint> box)
        {
            return crate.Zip(box, (x, y) => x / y).Aggregate((first, second) => first * second);
        }
    }
}