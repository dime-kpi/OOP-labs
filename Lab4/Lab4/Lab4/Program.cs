using Lab4.Commands;
using Lab4.DB;
using Lab4.DB.Service;
using ICommand = Lab4.Commands.ICommand;

namespace Lab4
{
    class Program
    {
        int temp = 1;
        public static void Main(string[] args)
        {
            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);
            Program program = new Program();
            program.Run(accountService, gameService);
        }
        public void Run(GameAccountService accountService, GameService gameService)
        {
            ICommand[] commands =
            [
                new EndProgramCommand(),
                new AddPlayerCommand(accountService),
                new ShowAllPlayersCommand(accountService),
                new StartGameCommand(accountService, gameService),
                new ShowAllGamesCommand(accountService),
                new ShowGamesForPlayerCommand(accountService),
            ];


            commands[1].Execute();
            commands[1].Execute();

            while (temp != 0)
            {
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Choose option:\n 1.Add new player\n 2.Show info about all players\n 3.Start game\n 4.Show info about all games\n 5.Show info about games of one player\n 0.End programme");
                temp = int.Parse(Console.ReadLine());

                commands[temp].Execute();
            }
        }
    }
}