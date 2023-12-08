using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public class Piece
    {
        private Color color;

        public Piece(Color c)
        {
            color = c;
        }

        public void flip()
        {
            if (color == Color.Black)
            {
                color = Color.White;
            }
            else
            {
                color = Color.Black;
            }
        }

        public Color getColor()
        {
            return color;
        }
    }
}
