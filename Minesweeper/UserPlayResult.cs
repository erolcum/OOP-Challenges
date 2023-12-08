using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class UserPlayResult
    {
        private bool successful;
        private GameState resultingState;
        public UserPlayResult(bool success, GameState state)
        {
            successful = success;
            resultingState = state;
        }

        public bool successfulMove()
        {
            return successful;
        }

        public GameState getResultingState()
        {
            return resultingState;
        }
    }
}
