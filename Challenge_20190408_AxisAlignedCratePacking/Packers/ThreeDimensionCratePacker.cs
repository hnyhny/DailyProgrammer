using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
using hnyhny.AxisAlignedCratePacking.Entities;
using hnyhny.Extensions;

namespace hnyhny.AxisAlignedCratePacking.Packers
{
    internal class ThreeDimensionCratePacker : CratePackerBase
    {
        private readonly IEnumerable<Space> boxes;

        internal ThreeDimensionCratePacker(uint[] input) : base(input, Dimensions.Three) {
            var boxDimensions = input.Skip(Dimensions.Three);
            this.boxes = boxDimensions.GetPermutations().Select(box => new Space(box.ToList()));
         }
        internal override uint Fit()
        {
            return boxes.Select(box => this.FitBoxes(box)).Max();
        }

        private uint FitBoxes(Space box)
        {
            return (this.Crate.X / box.X) * (this.Crate.Y / box.Y) * (this.Crate.Z / box.Z);
        }
    }
}