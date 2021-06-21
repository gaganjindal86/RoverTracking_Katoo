using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTracking.Interface
{
    public interface IRover
    {
        public int Orientation { get; set; }
        public int HorizontalLoc { get; set; }
        public int VerticalLoc { get; set; }
    }
}
