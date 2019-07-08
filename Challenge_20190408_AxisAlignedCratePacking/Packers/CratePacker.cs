using System.Linq;
using System;
using hnyhny.AxisAlignedCratePacking.Entities;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal class CratePacker : CratePackerBase
    {
        public CratePacker(uint[] input) : base(input, Dimensions.Two) { }
        internal override uint Fit()
        {
            return (Crate.X / Box.X) * (Crate.Y / Box.Y);
        }
    }
}
