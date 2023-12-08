using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    /* A helper class to automate this game. This is just used for testing purposes. */
    public class Automator
    {
        private Player[] players;
        private Player lastPlayer = null;
        public List<Location> remainingMoves = new List<Location>();
        private static Automator instance;

        private Automator()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Location loc = new Location(i, j);
                    remainingMoves.Add(loc);
                }
            }
        }

        public static Automator getInstance()
        {
            if (instance == null)
            {
                instance = new Automator();
            }
            return instance;
        }

        public void initialize(Player[] ps)
        {
            players = ps;
            lastPlayer = players[1];
        }

        public void shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < remainingMoves.Count; i++)
            {
                int t = rand.Next(i, remainingMoves.Count - 1);
                Location other = remainingMoves[t];
                Location current = remainingMoves[i];
                remainingMoves[t] = current;
                remainingMoves[i] = other;
            }
        }

        public void removeLocation(int r, int c)
        {
            for (int i = 0; i < remainingMoves.Count; i++)
            {
                Location loc = remainingMoves[i];
                if (loc.isSameAs(r, c))
                {
                    remainingMoves.RemoveAt(i);
                }
            }
        }

        public Location getLocation(int index)
        {
            return remainingMoves[index];
        }

        public bool playRandom()
        {
            Board board = Game.getInstance().getBoard();
            shuffle();
            lastPlayer = lastPlayer == players[0] ? players[1] : players[0];
            String color = lastPlayer.getColor().ToString();
            for (int i = 0; i < remainingMoves.Count; i++)
            {
                Location loc = remainingMoves[i];
                bool success = lastPlayer.playPiece(loc.getRow(), loc.getColumn());

                if (success)
                {
                    Console.WriteLine("Success: " + color + " move at (" + loc.getRow() + ", " + loc.getColumn() + ")");
                    board.printBoard();
                    printScores();
                    return true;
                }
            }
            Console.WriteLine("Game over. No moves found for " + color);
            return false;
        }

        public bool isOver()
        {
            if (players[0].getScore() == 0 || players[1].getScore() == 0)
            {
                return true;
            }
            return false;
        }

        public void printScores()
        {
            Console.WriteLine("Score: " + players[0].getColor().ToString() + ": " + players[0].getScore() + ", " + players[1].getColor().ToString() + ": " + players[1].getScore());
        }
    }
}
