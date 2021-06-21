using RoverTracking.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverTracking
{
    public class RoverValidation
    {
        Square square = new Square();
        Rover rover = new Rover();

        
        public void GetSquareInput()
        {
            Int32 width, height;
            String Orientation ;                            // intentionally string to support 2 char directions in future like NE, SW
            Clear(out width, out height, out Orientation);

            //get Square Values (Max area rover can go)
            Console.WriteLine("Please enter Square Width..");
            if (!int.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Please enter an integer value only, please close and run the program again");
                CloseProgram();
            }

            Console.WriteLine("Please enter Square Height..");
            if (!int.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Please enter an integer value only, please close and run the program again");
                CloseProgram();
            }

            //Initialiase Square
            square.HorizontalMax = width;
            square.VerticalMax = height;


            Clear(out width, out height, out Orientation);

            //Get Rover inputs
            Console.WriteLine("Please enter initial Orientation (Press single char in small case e.g. 'n' for north)..");
            Orientation = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();            

            switch (Orientation.ToUpper())
            {
                case "N":
                case "S":
                case "E":
                case "W":
                    break;
                default:
                    Console.WriteLine("Please enter an integer value only, please close and run the program again");
                    CloseProgram();
                    break;
            }
            Console.WriteLine("Please enter Rover's initial Horizontal location..");
            if (!int.TryParse(Console.ReadLine(), out width))
            {
                Console.WriteLine("Please enter an integer value only, please close and run the program again");
                CloseProgram();
            }

            Console.WriteLine("Please enter Rover's initial Vertical location..");
            if (!int.TryParse(Console.ReadLine(), out height))
            {
                Console.WriteLine("Please enter an integer value only, please close and run the program again");
                CloseProgram();
            }

            //Initialise rover
            DirectionEnum direction;
            Enum.TryParse(Orientation,true,out direction);
            rover.Orientation = Convert.ToInt32(direction);
            rover.HorizontalLoc = width;
            rover.VerticalLoc = height;

            var directionText = (DirectionEnum)rover.Orientation;
            Console.WriteLine("Current Orientation:" + directionText.ToString());
            Console.WriteLine("Current Horizontal Position:" + rover.HorizontalLoc);
            Console.WriteLine("Current Vertical Position:" + rover.VerticalLoc);
        }

        private static void CloseProgram()
        {
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static void Clear(out int SqWidth, out int Sqheight, out String Orientation)
        {
            SqWidth = 0;
            Sqheight = 0;
            Orientation = String.Empty;
        }
        public ValidationResult ValidateCommand(String cmd)
        {
            if(String.IsNullOrEmpty(cmd))
            {
                Console.WriteLine("Empty Command");
                CloseProgram();
            }
            else
            {
                cmd.ToUpper();
                for (Int32 i = 0; i < cmd.Length; i++)
                {
                    if (cmd[i] == 'A' || cmd[i] == 'L' || cmd[i] == 'R')
                    {
                        if (cmd[i] == 'A')
                        {
                            switch (rover.Orientation)
                            {
                                case 0:
                                    rover.VerticalLoc++;
                                    break;
                                case 1:
                                    rover.HorizontalLoc++;

                                    break;
                                case 2:
                                    rover.VerticalLoc--;
                                    break;
                                case 3:
                                    rover.HorizontalLoc--;
                                    break;
                            }
                        }
                        if (cmd[i] == 'L')
                        {
                            if(rover.Orientation == 0)      // because north --> left = west
                            {
                                rover.Orientation = 3;
                            }
                            else { rover.Orientation--; }
                        }
                        if (cmd[i] == 'R') 
                        {
                            rover.Orientation++;
                            rover.Orientation = rover.Orientation % 4; // because 5 means north, 8 west
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid Command character {cmd[i]}");
                        CloseProgram();
                    }
                }
            }            

            ValidationResult validationResult = new ValidationResult();
            validationResult.HorizontalLoc = rover.HorizontalLoc;
            validationResult.VerticalLoc = rover.VerticalLoc;
            validationResult.Orientation = rover.Orientation;
            validationResult.IsValidCommand = (rover.HorizontalLoc < 0 || rover.HorizontalLoc > square.HorizontalMax ||
                                               rover.VerticalLoc < 0 || rover.VerticalLoc > square.VerticalMax) ? false : true;

            return validationResult;
        }
        
    }
}
