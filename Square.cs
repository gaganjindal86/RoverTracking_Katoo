using RoverTracking.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTracking
{
    public class Square : ISquare
    {
        public int HorizontalMax { get; set; }
        public int VerticalMax { get; set; }
    }
}
