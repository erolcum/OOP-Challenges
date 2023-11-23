using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turtle_Graphics
{
    public class Turtle
    {
        public char turtleSymbol;
        public int positionX;
        public int positionY;

        public Turtle()
        {
            turtleSymbol = 'X';
            positionX = 0;
            positionY = 0;
        }

        public void walk(TurtleDirections direction, int spaces, PenActions pen) 
        {
            if (validateMove(direction, spaces))
            { 
                bool toDraw = (pen == PenActions.DOWN);
                switch (direction)
                {
                     case TurtleDirections.UP:
                        if (toDraw)
                            GameBoard.updateBoardUpDown(positionX, spaces, -1, positionY);
                        positionX -= spaces;
                        break;
                     case TurtleDirections.DOWN:
                     if (toDraw)
                        GameBoard.updateBoardUpDown(positionX, spaces, 1, positionY);
                        positionX += spaces;
                        break;
                    case TurtleDirections.RIGHT:
                        if (toDraw)
                            GameBoard.updateBoardRightLeft(positionY, spaces, 1, positionX);
                        positionY += spaces;
                        break;
                    case TurtleDirections.LEFT:
                        if (toDraw)
                            GameBoard.updateBoardRightLeft(positionY, spaces, -1, positionX);
                        positionY -= spaces;
                        break;
                }
            }
        }

        private bool validateMove(TurtleDirections direction, int spaces) 
        { 
            if (direction == TurtleDirections.UP && (positionX-spaces) < 0) 
            { 
                Messages.invalidMove(direction, positionX);
                return false;
            }
            if (direction == TurtleDirections.RIGHT && (positionY + spaces) > GameBoard.GAME_BOARD_SIZE-1)
            {
                Messages.invalidMove(direction, GameBoard.GAME_BOARD_SIZE - positionY -1);
                return false;
            }
            if (direction == TurtleDirections.DOWN && (positionX + spaces) > GameBoard.GAME_BOARD_SIZE - 1)
            {
                Messages.invalidMove(direction, GameBoard.GAME_BOARD_SIZE - positionX - 1);
                return false;
            }
            if (direction == TurtleDirections.LEFT && (positionY - spaces) < 0)
            {
                Messages.invalidMove(direction, positionY);
                return false;
            }
            return true;
        }
    }
}
