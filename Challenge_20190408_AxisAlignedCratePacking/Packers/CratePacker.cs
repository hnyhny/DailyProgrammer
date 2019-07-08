using System.Linq;
using System;
using hnyhny.AxisAlignedCratePacking.Entities;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal class CratePacker
    {
        private readonly Plane Crate;
        private readonly Plane Box;
        private int validInputLength = 4;
        public CratePacker(uint[] input)
        {
            if (input.Length != validInputLength)
                throw new NotSupportedException($"The input has to be an integer array of length {validInputLength}");

            this.Crate = new Plane(input[0], input[1]);
            this.Box = new Plane(input[2], input[3]);
        }
        internal uint Fit()
        {
            return (Crate.X / Box.X) * (Crate.Y / Box.Y);
        }
    }
}
