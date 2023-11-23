using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turtle_Graphics
{
    public class GameBoard
    {
        public const int GAME_BOARD_SIZE = 20;
        public const char USED_SPACE = 'o';
        public const char GAME_BOARD_SYMBOL = '.';
        public static char[,] gameBoardArray;

        public GameBoard()
        {
            gameBoardArray = new char[ GAME_BOARD_SIZE, GAME_BOARD_SIZE ];
        }

        public static void updateBoardUpDown(int start, int spacesToMove, int upOrDown, int y) 
        {
            for (int i = 0; i < spacesToMove; i++) 
            {
                gameBoardArray[start + (i * upOrDown), y ] = USED_SPACE;
            }
        }
        public static void updateBoardRightLeft(int start, int spacesToMove, int rightOrLeft, int x)
        {
            for (int i = 0; i < spacesToMove; i++)
            {
                gameBoardArray[ x , start + (i * rightOrLeft)] = USED_SPACE;
            }
        }

        public void initGameBoard() 
        {
            for (int i = 0; i < gameBoardArray.GetLength(0); i++) 
            {
                for (int j = 0; j < gameBoardArray.GetLength(1); j++) 
                {
                    gameBoardArray[i, j] = GAME_BOARD_SYMBOL;
                }
            }
        }

        public void drawGameBoard(int posX, int posY, char turtle)
        {
            for (int i = 0; i < gameBoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoardArray.GetLength(1); j++)
                {
                    if (i==posX && j==posY) 
                    {
                        Console.Write(turtle + " ");
                    }
                    else
                        Console.Write(gameBoardArray[i, j] + " ");  
                }
                Console.WriteLine();
            }
        }

    }
}
