using KR.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.GameTypes
{
    class EasyGame : Game
    {
        public EasyGame(Account player, GameService service, int rows = 5, int cols = 5, int minesCount = 4) : base(player, service, rows, cols, minesCount) { }
    }
}
