using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Minesweeper
{
    public class Board
    {
        private int nRows;
        private int nColumns;
        private int nBombs = 0;
        private Cell[,] cells;
        private Cell[] bombs;
        private int numUnexposedRemaining;


        public Board(int r, int c, int b)
        {
            nRows = r;
            nColumns = c;
            nBombs = b;

            initializeBoard();
            shuffleBoard();
            setNumberedCells();

            numUnexposedRemaining = nRows * nColumns - nBombs;
        }

        private void initializeBoard()
        {
            cells = new Cell[nRows,nColumns];
            bombs = new Cell[nBombs];
            for (int r = 0; r < nRows; r++)
            {
                for (int c = 0; c < nColumns; c++)
                {
                    cells[r,c] = new Cell(r, c);
                }
            }

            for (int i = 0; i < nBombs; i++)
            {
                int r = i / nColumns;
                int c = (i - r * nColumns) % nColumns;
                bombs[i] = cells[r,c];
                bombs[i].setBomb(true);
            }
        }

        private void shuffleBoard()
        {
            int nCells = nRows * nColumns;
            Random random = new Random();
            for (int index1 = 0; index1 < nCells; index1++)
            {
                int index2 = index1 + random.Next(nCells - index1);
                if (index1 != index2)
                {
                    /* Get cell at index1. */
                    int row1 = index1 / nColumns;
                    int column1 = (index1 - row1 * nColumns) % nColumns;
                    Cell cell1 = cells[row1,column1];

                    /* Get cell at index2. */
                    int row2 = index2 / nColumns;
                    int column2 = (index2 - row2 * nColumns) % nColumns;
                    Cell cell2 = cells[row2,column2];

                    /* Swap. */
                    cells[row1,column1] = cell2;
                    cell2.setRowAndColumn(row1, column1);
                    cells[row2,column2] = cell1;
                    cell1.setRowAndColumn(row2, column2);
                }
            }
        }

        private bool inBounds(int row, int column)
        {
            return row >= 0 && row < nRows && column >= 0 && column < nColumns;
        }

        /* Set the cells around the bombs to the right number. Although 
         * the bombs have been shuffled, the reference in the bombs array
         * is still to same object. */
        private void setNumberedCells()
        {
            int[,] deltas = { // Offsets of 8 surrounding cells
				{-1, -1}, {-1, 0}, {-1, 1},
                { 0, -1},          { 0, 1},
                { 1, -1}, { 1, 0}, { 1, 1}
        };
  
            foreach (Cell bomb in bombs) 
            {
                int row = bomb.getRow();
                int col = bomb.getColumn();
                for (int i=0; i < deltas.GetLength(0); i++)
                {
                    int r = row + deltas[i,0];
                    int c = col + deltas[i,1];
                    if (inBounds(r, c))
                    {
                        cells[r, c].incrementNumber();
                    }
                }

            }
        }

        public void printBoard(bool showUnderside)
        {
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 0; i < nColumns; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < nColumns + 1; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine();
            for (int r = 0; r < nRows; r++)
            {
                Console.Write(r + "| ");
                for (int c = 0; c < nColumns; c++)
                {
                    if (showUnderside)
                    {
                        Console.Write(cells[r,c].getUndersideState());
                    }
                    else
                    {
                        Console.Write(cells[r,c].getSurfaceState());
                    }
                }
                Console.WriteLine();
            }
        }

        private bool flipCell(Cell cell)
        {
            if (!cell.IsExposed() && !cell.IsGuess())
            {
                cell.flip();
                numUnexposedRemaining--;
                return true;
            }
            return false;
        }

        public void expandBlank(Cell cell)
        {
            int[,] deltas = {
                {-1, -1}, {-1, 0}, {-1, 1},
                { 0, -1},          { 0, 1},
                { 1, -1}, { 1, 0}, { 1, 1}
        };

            List<Cell> toExplore = new List<Cell>();
            toExplore.Add(cell); 

            while (!(toExplore.Count == 0))
            {
                Cell current = toExplore[0];
                toExplore.RemoveAt(0);

                for(int i=0; i < deltas.GetLength(0); i++)
                {
                    int r = current.getRow() + deltas[i,0];
                    int c = current.getColumn() + deltas[i,1];

                    if (inBounds(r, c))
                    {
                        Cell neighbor = cells[r, c];
                        if (flipCell(neighbor) && neighbor.isBlank())
                        {
                            toExplore.Add(neighbor);
                        }
                    }
                }
            }
        }

        public UserPlayResult playFlip(UserPlay play)
        {
            Cell cell = getCellAtLocation(play);
            if (cell == null)
            {
                return new UserPlayResult(false, GameState.RUNNING);
            }

            if (play.IsGuess())
            {
                bool guessResult = cell.toggleGuess();
                return new UserPlayResult(guessResult, GameState.RUNNING);
            }

            bool result = flipCell(cell);

            if (cell.IsBomb())
            {
                return new UserPlayResult(result, GameState.LOST);
            }

            if (cell.isBlank())
            {
                expandBlank(cell);
            }

            if (numUnexposedRemaining == 0)
            {
                return new UserPlayResult(result, GameState.WON);
            }

            return new UserPlayResult(result, GameState.RUNNING);
        }

        public Cell getCellAtLocation(UserPlay play)
        {
            int row = play.getRow();
            int col = play.getColumn();
            if (!inBounds(row, col))
            {
                return null;
            }
            return cells[row,col];
        }

        public int getNumRemaining()
        {
            return numUnexposedRemaining;
        }
    }
}
