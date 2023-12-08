using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi
{
    public class Game
    {
        private Player[] players;
        private static Game instance;
        private Board board;
        private const int ROWS = 10;
        private const int COLUMNS = 10;

        private Game()
        {
            board = new Board(ROWS, COLUMNS);
            players = new Player[2];
            players[0] = new Player(Color.Black);
            players[1] = new Player(Color.White);
            Automator.getInstance().initialize(players); // used for testing
        }

        public static Game getInstance()
        {
            if (instance == null)
            {
                instance = new Game();
            }
            return instance;
        }

        public Board getBoard()
        {
            return board;
        }
    }
}
