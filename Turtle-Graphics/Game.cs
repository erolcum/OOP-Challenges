using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Turtle_Graphics
{
    public  class Game
    {
        private PenActions pen;
        private TurtleDirections direction;
        private Turtle turtle;
        private GameBoard board;
        private bool quit;
        private int option;
        public Game() 
        { 
            turtle = new Turtle();
            board = new GameBoard();
            quit = false;
            pen = PenActions.UP;
            direction = TurtleDirections.UP;
        
        }

        public void gameLoop() 
        { 
            board.initGameBoard();

            do
            {
                Console.Clear();
                Console.WriteLine(Messages.errorMessage);
                Messages.errorMessage = "";
                board.drawGameBoard(turtle.positionX, turtle.positionY, turtle.turtleSymbol);
                Messages.instructions();
                Console.WriteLine("Pen is " + (pen == PenActions.UP ? "NOT DRAWING" : "DRAWING" ));
                Console.WriteLine("Turtle is moving " + direction);
                Console.Write("Select your option : ");
                option = int.Parse(Console.ReadLine());
                if (option == 1)
                    pen = PenActions.UP;
                else if (option == 2)
                    pen = PenActions.DOWN;
                else if (option == 3)
                    direction = TurtleDirections.UP;
                else if (option == 4)
                    direction = TurtleDirections.RIGHT;
                else if (option == 5)
                    direction = TurtleDirections.DOWN;
                else if (option == 6)
                    direction = TurtleDirections.LEFT;
                else if (option == 7)
                    quit = true;
                else
                    Messages.invalidInput();

                if (option == 3 || option == 4 || option == 5 || option == 6) 
                {
                    Console.WriteLine("Turtle is moving " + direction);
                    Console.Write("Enter the number of spaces to move : ");
                    int spaces = int.Parse(Console.ReadLine());
                    turtle.walk(direction, spaces, pen);
                }

            } while (!quit);
        }
    }
}
