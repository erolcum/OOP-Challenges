using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public class Player
    {
        private Color color;
        public Player(Color c)
        {
            color = c;
        }

        public int getScore()
        {
            return Game.getInstance().getBoard().getScoreForColor(color);
        }

        public bool playPiece(int row, int column)
        {
            return Game.getInstance().getBoard().placeColor(row, column, color);
        }

        public Color getColor()
        {
            return color;
        }
    }
}
