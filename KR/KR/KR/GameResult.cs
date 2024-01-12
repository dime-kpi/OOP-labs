using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    internal class GameResult
    {
        public string Player { get; set; }
        public string IsWin { get; set; }
        public int Rating { get; set; }
        public int GameIndex { get; set; }

        public GameResult(string player, string isWin, int rating, int gameIndex)
        {
            Player = player;
            IsWin = isWin;
            Rating = rating;
            GameIndex = gameIndex;
        }
        public GameResult() { }
    }
}
