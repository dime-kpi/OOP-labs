using KR.DB.Service;
using KR.DB;
using KR.Commands;
using System.Numerics;

namespace KR
{
    class Program
    {
        public static void Main()
        {
            int temp = 1;
            var context = new DbContext();
            var accountService = new AccountService(context);
            var gameService = new GameService(context);

            Console.WriteLine("----MINESWEPER----");

            ICommand[] commands =
            [
                new EndProgramCom(),
                new AddPlayerCom(accountService),
                new StartGameCom(accountService, gameService),
                new ShowGamesCom(accountService),
                new ShowPlayerCom(accountService)
            ];

            while (temp != 0)
            {
                Console.WriteLine("------------------------------------------------");
                bool a = false;
                for (int i = 0; i < commands.Length; i++)
                {
                    commands[i].ShowCommand(i);
                }
                
                while (a == false)
                {
                    Console.WriteLine("Choose option:");
                    temp = int.Parse(Console.ReadLine());
                    if (temp < 0 || temp > commands.Length)
                    {
                        Console.WriteLine("Incorrect option!!!");
                    }
                    else
                    {
                        a = true;
                    }
                }

                commands[temp].Execute();
            }
        }
    }
}