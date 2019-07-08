using System.Collections;
using System.Linq;
using System;
using hnyhny.AxisAlignedCratePacking.Entities;
using System.Collections.Generic;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal class CratePacker
    {
        private const int validInputLength = 4;
        internal uint Fit(IList<uint> input)
        {
            if (input.Count() != validInputLength)
                throw new NotSupportedException($"The input has to be an integer array of length {validInputLength}");

            var Crate = new Plane(input[0], input[1]);
            var Box = new Plane(input[2], input[3]);

            return (Crate.X / Box.X) * (Crate.Y / Box.Y);
        }
    }
}
