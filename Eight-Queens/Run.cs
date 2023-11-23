using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_Queens
{
    public class Run
    {
        private Board board;
        private int runCounter;
        private int queensCounter; // 8 queens
        private static Random r;
        private bool[] usedRows; // to check if row available (no queen)

        public Run()
        {
            usedRows = new bool[8];
            r = new Random();
            board = new Board();
            runCounter = 0;
            queensCounter = 0;
        }

        public bool isWinner() // diagonal check
        { 
            board.displayBoard();
            Console.WriteLine();
            int attackingQueenCounter = 0;
            for (int i = 0; i < 7; i++) // cols
            { 
                for (int j = 0; j < 7 - i ; j++) // rows but diagonal
                { 
                    if (board.board[j, i+j] != Board.BOARD_CHAR) 
                    { 
                        attackingQueenCounter++;
                        if (countQueens(attackingQueenCounter)==false)
                            return false;
                    }
                }
                attackingQueenCounter = 0;
            }
            attackingQueenCounter = 0;
            for (int i = 0; i < 7; i++) // rows
            {
                for (int j = 7; j >= i ; j--) // cols  but diagonal
                {
                    if (board.board[7-j+i, j] != Board.BOARD_CHAR)
                    {
                        attackingQueenCounter++;
                        if (countQueens(attackingQueenCounter) == false)
                            return false;
                    }
                }
                attackingQueenCounter = 0;
            }
            attackingQueenCounter = 0;
            for (int i = 7; i > 0; i--) 
            {
                for (int j = 7; j >= 7 - i; j--) 
                {
                    if (board.board[j, i + j -7] != Board.BOARD_CHAR)
                    {
                        attackingQueenCounter++;
                        if (countQueens(attackingQueenCounter) == false)
                            return false;
                    }
                }
                attackingQueenCounter = 0;
            }
            attackingQueenCounter = 0;
            for (int i = 7; i > 0; i--)
            {
                for (int j = 0; j <= i ; j++)
                {
                    if (board.board[i-j, j] != Board.BOARD_CHAR)
                    {
                        attackingQueenCounter++;
                        if (countQueens(attackingQueenCounter) == false)
                            return false;
                    }
                }
                attackingQueenCounter = 0;
            }
            return true;
        }

        private bool countQueens(int attackingQueenCounter) 
        { 
            if (attackingQueenCounter > 1) 
            {
                queensCounter = 0;
                usedRows = new bool[8];
                board.init();
                return false;
            }
            return true;
        }

        public bool isValidRow(int row) 
        { 
            if (usedRows[row] == false) 
            {
                usedRows[row] = true;
                return true;
            }
            return false;
        }

        public void setPositions() 
        {
            int row = 0; int col = 0;
            while (queensCounter < 8) 
            {
                row = r.Next(8);
                if (isValidRow(row)) 
                {
                    board.board[row, col] = Board.QUEEN_CHAR;
                    col++;
                    queensCounter++;
                }
            }
            runCounter++;
        }

        public void placeQueens() 
        {
            board.init();
            do
            {
                setPositions();
                Console.WriteLine(runCounter);
            } while (!isWinner());
            Console.WriteLine("it took " + runCounter + " attempts to find");
        }
    }
}
