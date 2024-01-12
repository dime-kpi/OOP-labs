using KR.DB.Service;
using KR.DB.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Commands
{
    internal class ShowGamesCom : ICommand
    {
        private readonly AccountService _accountService;
        public ShowGamesCom(AccountService accountService)
        {
            _accountService = accountService;
        }
        public void Execute()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input user name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input user password: ");
            string password = Console.ReadLine();
            List<Account> players = _accountService.ReadAll();
            foreach (Account player in players)
            {
                if (player.UserName == name && player.Password == password)
                {
                    List<GameResult> games = _accountService.GameResults(player);
                    foreach (GameResult game in games)
                    {
                        Console.WriteLine($"Player {game.Player} {game.IsWin}, Played for {game.Rating} rating, Game №{game.GameIndex}");
                    }
                }
            }
            
        }

        public void ShowCommand(int i)
        {
            Console.WriteLine($"{i}) Show games info");
        }
    }
}
