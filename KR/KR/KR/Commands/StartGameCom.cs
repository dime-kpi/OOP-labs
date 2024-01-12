using KR.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Commands
{
    internal class StartGameCom : ICommand
    {
        private readonly AccountService _accountService;
        private readonly GameService _gameService;
        private Account player;

        public StartGameCom(AccountService accountService, GameService gameService)
        {
            _accountService = accountService;
            _gameService = gameService;
        }
        public void Execute()
        {
            player = Login(_accountService);
            Console.WriteLine("------------------------------------------------");
            Game game = GameType(player, _gameService);
            game.StartGame();
        }

        private Account Login(AccountService accountService)
        {
            Console.WriteLine("Input user name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input user password: ");
            string password = Console.ReadLine();
            List<Account> players = accountService.ReadAll();
            foreach (Account player in players)
            {
                if (player.UserName == name && player.Password == password)
                {
                    return player;
                }
            }
            return Login(accountService);
        }

        private Game GameType(Account player, GameService service)
        {
            Console.WriteLine("Choose game type: \n1.Easy game \n2.Middle game \n3.Hard game");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateEasyGame(player, service);
                case 2:
                    return factory.CreateMiddleGame(player, service);
                case 3:
                    return factory.CreateHardGame(player, service);
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return GameType(player, service);
            }
        }

        public void ShowCommand(int i)
        {
            Console.WriteLine($"{i}) Start game");
        }
    }
}
