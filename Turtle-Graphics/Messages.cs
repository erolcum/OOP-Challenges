using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turtle_Graphics
{
    public class Messages
    {
        public static void instructions() 
        {
            Console.WriteLine("Type your commands to draw");
            Console.WriteLine("1 = pen up; 2 = pen down");
            Console.WriteLine("3 = up; 4 = right; 5 = down; 6 = left");
            Console.WriteLine("7 = quit");
        }

        public static string errorMessage = "";
        public static void invalidInput() 
        {
            errorMessage = "\nINVALID INPUT input must be an int between 1 - 7\n";
        }

        public static void invalidMove(TurtleDirections direction, int spaces) 
        {
            errorMessage = "\nINVALID MOVE you can move " + spaces + " to the direction " + direction + "\n";
        }
    }
}
