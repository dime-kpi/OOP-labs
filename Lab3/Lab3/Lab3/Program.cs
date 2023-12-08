using Lab3.DB;
using Lab3.DB.Service;
using Lab3.GameAccountTypes;

namespace Lab3
{
    class Program
    {
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
            Console.WriteLine("Input first player name: ");
            string firstPlayer = Console.ReadLine();
            GameAccount player1 = AccountChose(accountService, firstPlayer);
            Console.WriteLine("Input second player name: ");
            string secondPlayer = Console.ReadLine();
            GameAccount player2 = AccountChose(accountService, secondPlayer);
            string answer;
            do
            {
                Console.WriteLine("------------------------------------------------");
                Game game = GameType(player1, player2, gameService);
                game.PlayGame(player1, player2);
                Console.WriteLine("Play again? (Y/N)");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
            Console.WriteLine("------------------------------------------------");
            GetStats(accountService);
        }

        public void GetStats(GameAccountService accountService)
        {
            var listAccounts = accountService.ReadAll();
            foreach (var account in listAccounts)
            {
                account.GetStats();
            }
        }

        private GameAccount AccountChose(GameAccountService service, string userName)
        {
            Console.WriteLine("Choose account type: \n1.StandartAccount \n2.HalfAccount \n3.2xAccount");
            int choose = int.Parse(Console.ReadLine());
            var Id = service.ReadAll().Count();
            switch (choose)
            {
                case 1:
                    var standartGameAccount = new StandartAccount(service, Id, userName);
                    service.Create(standartGameAccount);
                    return standartGameAccount;
                case 2:
                    var halfGameAccount = new HalfAccount(service, Id, userName);
                    service.Create(halfGameAccount);
                    return halfGameAccount;
                case 3:
                    var doubleGameAccount = new DoubleAccount(service, Id, userName);
                    service.Create(doubleGameAccount);
                    return doubleGameAccount;
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return AccountChose(service, userName);
            }
        }

        private Game GameType(GameAccount player1, GameAccount player2, GameService service)
        {
            Console.WriteLine("Choose game type: \n1.StandartGame \n2.UnrankedGame \n3.SafeGame");
            int choose = int.Parse(Console.ReadLine());
            GameFactory factory = new GameFactory();
            switch (choose)
            {
                case 1:
                    return factory.CreateStandartGame(player1, player2, service);
                case 2:
                    return factory.CreateUnrankedGame(player1, player2, service);
                case 3:
                    return factory.CreateSafeGame(player1, player2, service);
                default:
                    Console.WriteLine("Incorrect. Write number between 1-3");
                    return GameType(player1, player2, service);
            }
        }
    }
}