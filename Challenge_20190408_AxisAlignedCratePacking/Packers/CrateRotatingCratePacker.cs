using System;
using hnyhny.AxisAlignedCratePacking.Entities;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal class CrateRotatingCratePacker : CratePackerBase
    {
        internal CrateRotatingCratePacker(uint[] input) : base(input, Dimensions.Two) { }
        internal override uint Fit()
        {
            var normalFit = (Crate.X / Box.X) * (Crate.Y / Box.Y);
            var rotatedFit = (Crate.X / Box.Y) * (Crate.Y / Box.X);

            return Math.Max(normalFit, rotatedFit);
        }
    }
}