using KR.DB.Service;
using KR.GameTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR
{
    internal class GameFactory
    {
        public Game CreateEasyGame(Account player, GameService service)
        {
            return new EasyGame(player, service);
        }
        public Game CreateMiddleGame(Account player, GameService service)
        {
            return new MiddleGame(player, service);
        }
        public Game CreateHardGame(Account player, GameService service)
        {
            return new HardGame(player, service);
        }
    }
}
