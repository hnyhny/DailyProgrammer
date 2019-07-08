using System.Numerics;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using hnyhny.Extensions;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal class NDimensionCratePacker
    {
        private readonly IEnumerable<uint> crate;
        private readonly IEnumerable<uint> box;

        public NDimensionCratePacker(IEnumerable<IEnumerable<uint>> input)
        {
            this.crate = input.First();
            this.box = input.Skip(1).First();
        }
        internal BigInteger Fit()
        {
            var boxPermutations = box.GetPermutations();
            return boxPermutations.Select(CalculateFit).Max();
        }
        internal BigInteger CalculateFit(IEnumerable<uint> box)
        {
            return crate.Zip(box, (x, y) => x / y).Aggregate((first, second) => first * second);
        }
    }
}