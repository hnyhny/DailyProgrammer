using System.Collections.Generic;
using System.Linq;
using System;
namespace hnyhny.AxisAlignedCratePacking.Entities
{
    public class Space
    {
        public readonly uint X = 0;
        public readonly uint Y = 0;
        public readonly uint Z = 0;

        public Space(IList<uint> values)
        {

            if (!values.Any() || values.Count() > 3)
                throw new NotSupportedException("The input has to have between 1 and 3 values");

            if (values.Count() == 3)
                this.Z = values[2];

            if (values.Count() > 1)
                this.Y = values[1];

            this.X = values[0];
        }
        public Space(uint x, uint y)
        {
            this.X = x;
            this.Y = y;
        }

        public Space(uint x, uint y, uint z) : this(x, y)
        {
            this.Z = z;
        }
    }
}
