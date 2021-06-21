using System;

namespace RoverTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            RoverValidation roverValidation = new RoverValidation();
            roverValidation.GetSquareInput();
            while (1==1)
            {
                Console.WriteLine("Please enter rover command now..");
                String cmd = Console.ReadLine();

                ValidationResult result = roverValidation.ValidateCommand(cmd);

                Console.WriteLine("Is Valid command or not:" + (result.IsValidCommand ? "True" : "False"));
                var directionText = (DirectionEnum)result.Orientation;
                Console.WriteLine("Current Orientation:" + directionText.ToString());
                Console.WriteLine("Current Horizontal Position:" + result.HorizontalLoc);
                Console.WriteLine("Current Vertical Position:" + result.VerticalLoc);                
            }
        }
        
    }
}
