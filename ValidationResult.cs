using RoverTracking.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTracking
{
    public class ValidationResult : Rover
    {
        public Boolean IsValidCommand { get; set; }
    }
}
