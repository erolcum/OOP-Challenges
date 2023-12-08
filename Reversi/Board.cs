using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public enum Color
    {
        White, Black
    }
    public enum Direction
    {
        left, right, up, down
    }
    public class Board
    {
        private int blackCount = 0;
        private int whiteCount = 0;
        private  Piece[,] board;

        public Board(int rows, int columns)
        {
            board = new Piece[rows,columns];
        }

        public void initialize()
        {
            /* initial board has a grid like the following in the center:
             *     WB
             *     BW
             */
            int middleRow = board.GetLength(0) / 2 - 1;
            int middleColumn = board.GetLength(1) / 2 - 1;
            board[middleRow,middleColumn] = new Piece(Color.White);
            board[middleRow + 1,middleColumn] = new Piece(Color.Black);
            board[middleRow + 1,middleColumn + 1] = new Piece(Color.White);
            board[middleRow,middleColumn + 1] = new Piece(Color.Black);
            blackCount = 2;
            whiteCount = 2;
        }

        public bool placeColor(int row, int column, Color color)
        {
            if (board[row,column] != null)
            {
                return false;
            }

            /* attempt to flip each of the four directions */
            int[] results = new int[4];
            results[0] = flipSection(row - 1, column, color, Direction.up);
            results[1] = flipSection(row + 1, column, color, Direction.down);
            results[2] = flipSection(row, column + 1, color, Direction.right);
            results[3] = flipSection(row, column - 1, color, Direction.left);

            /* compute how many pieces were flipped */
            int flipped = 0;
            foreach (int result in results) 
            {
                if (result > 0)
                {
                    flipped += result;
                }
            }

            /* if nothing was flipped, then it's an invalid move */
            if (flipped < 0)
            {
                return false;
            }

            /* flip the piece, and update the score */
            board[row,column] = new Piece(color);
            updateScore(color, flipped + 1);
            return true;
        }

        private int flipSection(int row, int column, Color color, Direction d)
        {
            /* Compute the delta for the row and the column. At all times, only the row or the column
             * will have a delta, since we're only moving in one direction at a time.
             */
            int r = 0;
            int c = 0;
            switch (d)
            {
                case Direction.up:
                    r = -1;
                    break;
                case Direction.down:
                    r = 1;
                    break;
                case Direction.left:
                    c = -1;
                    break;
                case Direction.right:
                    c = 1;
                    break;
            }

            /* If out of bounds, or nothing to flip, return an error (-1) */
            if (row < 0 || row >= board.GetLength(0) || column < 0 || column >= board.GetLength(1) || board[row,column] == null)
            {
                return -1;
            }

            /* Found same color - return nothing flipped */
            if (board[row,column].getColor() == color)
            {
                return 0;
            }

            /* Recursively flip the remainder of the row. If -1 is returned, then we know we hit the boundary
             * of the row (or a null piece) before we found our own color, so there's nothing to flip. Return
             * the error code.
             */
            int flipped = flipSection(row + r, column + c, color, d);
            if (flipped < 0)
            {
                return -1;
            }

            /* flip our own color */
            board[row,column].flip();
            return flipped + 1;
        }

        public int getScoreForColor(Color c)
        {
            if (c == Color.Black)
            {
                return blackCount;
            }
            else
            {
                return whiteCount;
            }
        }

        public void updateScore(Color newColor, int newPieces)
        {
            /* If we added x pieces of a color, then we actually removed x - 1 pieces of the other
             * color. The -1 is because one of the new pieces was the just-placed one.
             */
            if (newColor == Color.Black)
            {
                whiteCount -= newPieces - 1;
                blackCount += newPieces;
            }
            else
            {
                blackCount -= newPieces - 1;
                whiteCount += newPieces;
            }
        }

        public void printBoard()
        {
            for (int r = 0; r < board.GetLength(0); r++)
            {
                for (int c = 0; c < board.GetLength(1); c++)
                {
                    if (board[r,c] == null)
                    {
                        Console.Write("_");
                    }
                    else if (board[r,c].getColor() == Color.White)
                    {
                        Console.Write("W");
                    }
                    else
                    {
                        Console.Write("B");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
