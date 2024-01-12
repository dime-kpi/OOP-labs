using KR.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Commands
{
    internal class ShowPlayerCom : ICommand
    {
        private readonly AccountService _service;
        public ShowPlayerCom(AccountService service)
        {
            _service = service;
        }

        public void Execute()
        {
            Console.WriteLine("------------------------------------------------");
            ShowPlayer(Login(_service));
        }

        private void ShowPlayer(Account player)
        {
            Console.WriteLine($"Player ID: {player.Id}, name: {player.UserName}, current rating: {player.CurrentRating}, games played: {player.GamesCount}");
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

        public void ShowCommand(int i)
        {
            Console.WriteLine($"{i}) Show player info");
        }
    }
}
