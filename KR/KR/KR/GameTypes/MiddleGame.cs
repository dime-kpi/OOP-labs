using KR.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.GameTypes
{
    internal class MiddleGame : Game
    {
        public MiddleGame(Account player, GameService service, int rows = 7, int cols = 7, int minesCount = 7) : base(player, service, rows, cols, minesCount) { }
    }
}
