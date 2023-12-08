using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public enum GameState
    {
        WON, LOST, RUNNING
    }
    public class Game
    {
        private Board board;
        private int rows;
        private int columns;
        private int bombs;
        private GameState state;

        public Game(int r, int c, int b)
        {
            rows = r;
            columns = c;
            bombs = b;
            state = GameState.RUNNING;
        }

        public bool initialize()
        {
            if (board == null)
            {
                board = new Board(rows, columns, bombs);
                board.printBoard(true);
                return true;
            }
            else
            {
                Console.WriteLine("Game has already been initialized.");
                return false;
            }
        }

        public bool start()
        {
            if (board == null)
            {
                initialize();
            }
            return playGame();
        }

        public void printGameState()
        {
            if (state == GameState.LOST)
            {
                board.printBoard(true);
                Console.WriteLine("FAIL");
            }
            else if (state == GameState.WON)
            {
                board.printBoard(true);
                Console.WriteLine("WIN");
            }
            else
            {
                Console.WriteLine("\nNumber remaining: " + board.getNumRemaining());
                board.printBoard(false);
            }
        }

        private bool playGame()
        {
            printGameState();

            while (state == GameState.RUNNING)
            {
                String input = Console.ReadLine();
                if (input.Equals("exit"))
                {
                    return false;
                }

                UserPlay play = UserPlay.fromString(input);
                if (play == null)
                {
                    continue;
                }

                UserPlayResult result = board.playFlip(play);
                if (result.successfulMove())
                {
                    state = result.getResultingState();
                }
                else
                {
                    Console.WriteLine("Could not flip cell (" + play.getRow() + "," + play.getColumn() + ").");
                }
                printGameState();
            }
            return true;
        }
    }
}
