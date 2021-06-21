using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTracking.Interface
{
    public interface ISquare
    {
        public int HorizontalMax { get; set; }
        public int VerticalMax { get; set; }
    }
}
