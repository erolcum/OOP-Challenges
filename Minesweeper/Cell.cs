using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Cell
    {
        private int row;
        private int column;
        private bool isBomb;
        private int number;
        private bool isExposed = false;
        private bool isGuess = false;

        public Cell(int r, int c)
        {
            isBomb = false;
            number = 0;
            row = r;
            column = c;
        }

        public void setRowAndColumn(int r, int c)
        {
            row = r;
            column = c;
        }

        public void setBomb(bool bomb)
        {
            isBomb = bomb;
            number = -1;
        }

        public void incrementNumber()
        {
            number++;
        }

        public int getRow()
        {
            return row;
        }

        public int getColumn()
        {
            return column;
        }

        public bool IsBomb()
        {
            return isBomb;
        }

        public bool isBlank()
        {
            return number == 0;
        }

        public bool IsExposed()
        {
            return isExposed;
        }

        public bool flip()
        {
            isExposed = true;
            return !isBomb;
        }

        public bool toggleGuess()
        {
            if (!isExposed)
            {
                isGuess = !isGuess;
            }
            return isGuess;
        }

        public bool IsGuess()
        {
            return isGuess;
        }

       
    public String toString()
        {
            return getUndersideState();
        }

        public String getSurfaceState()
        {
            if (isExposed)
            {
                return getUndersideState();
            }
            else if (isGuess)
            {
                return "B ";
            }
            else
            {
                return "? ";
            }
        }

        public String getUndersideState()
        {
            if (isBomb)
            {
                return "* ";
            }
            else if (number > 0)
            {
                return Convert.ToString(number) + " ";
            }
            else
            {
                return "  ";
            }
        }
    }
}
