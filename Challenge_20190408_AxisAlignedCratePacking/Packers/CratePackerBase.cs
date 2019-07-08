using System;
using System.Linq;
using hnyhny.AxisAlignedCratePacking.Entities;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal abstract class CratePackerBase
    {
        internal readonly int dimensions;

        internal readonly Space Crate;
        internal readonly Space Box;

        public CratePackerBase(uint[] input, int dimensions)
        {
            int validInputLength = dimensions * 2;
            if (input.Length != validInputLength)
                throw new NotSupportedException($"The input has to be an integer array of length {validInputLength}");

            this.dimensions = dimensions;
            this.Crate = new Space(input.Take(dimensions).ToList());
            this.Box = new Space(input.Skip(dimensions).ToList());
        }
        internal abstract uint Fit();
    }
}