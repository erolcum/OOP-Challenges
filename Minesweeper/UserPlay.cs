using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class UserPlay
    {
        private int row;
        private int column;
        private bool isGuess;

        private UserPlay(int r, int c, bool guess)
        {
            setRow(r);
            setColumn(c);
            isGuess = guess;
        }

        public static UserPlay fromString(String input)
        {
            bool isGuess = false;

            if (input.Length > 0 && input[0] == 'B')
            {
                isGuess = true;
                input = input.Substring(1);
            }

            //if (!input.matches("\\d* \\d+"))
            //{
            //    return null;
            //}

            String[] parts = input.Split(' ');
            try
            {
                int r = int.Parse(parts[0]);
                int c = int.Parse(parts[1]);
                return new UserPlay(r, c, isGuess);
            }
            catch (FormatException e)
            {
                return null;
            }
        }

        public bool IsGuess()
        {
            return isGuess;
        }

        public bool isMove()
        {
            return !isMove();
        }

        public int getColumn()
        {
            return column;
        }

        public void setColumn(int column)
        {
            this.column = column;
        }

        public int getRow()
        {
            return row;
        }

        public void setRow(int row)
        {
            this.row = row;
        }
    }
}
