using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Eight_Queens
{
    public class Board
    {
        public const char BOARD_CHAR = '.';
        public const char QUEEN_CHAR = 'o';
        public char[,] board;
        public Board() 
        { 
            board = new char[8,8];
        }

        public void init() 
        { 
            for (int i = 0; i < 8; i++) 
            {
                for (int j = 0; j < 8; j++) 
                {
                    board[i,j] = BOARD_CHAR;
                }
            }
        }
        
        public void displayBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(board[i, j] + "   ");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
