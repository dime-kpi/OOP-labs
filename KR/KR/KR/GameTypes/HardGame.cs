using KR.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.GameTypes
{
    internal class HardGame : Game
    {
        public HardGame(Account player, GameService service, int rows = 10, int cols = 10, int minesCount = 15) : base(player, service, rows, cols, minesCount) { }
    }
}
