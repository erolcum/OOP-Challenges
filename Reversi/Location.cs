using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public class Location
    {
        private int row;
        private int column;
        public Location(int r, int c)
        {
            row = r;
            column = c;
        }

        public bool isSameAs(int r, int c)
        {
            return row == r && column == c;
        }

        public int getRow()
        {
            return row;
        }

        public int getColumn()
        {
            return column;
        }
    }
}
