using KR.DB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Commands
{
    internal class AddPlayerCom : ICommand
    {
        private readonly AccountService _accountService;
        public AddPlayerCom(AccountService gameAccountService)
        {
            _accountService = gameAccountService;
        }

        public void Execute()
        {
            Console.WriteLine("------------------------------------------------");
            var Id = _accountService.ReadAll().Count();
            Console.WriteLine("Input player name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Input player password:");
            string password = Console.ReadLine();
            Account player = new Account(_accountService, Id, userName, password);
            _accountService.Create(player);
        }

        public void ShowCommand(int i)
        {
            Console.WriteLine($"{i}) Add new player");
        }
    }
}
