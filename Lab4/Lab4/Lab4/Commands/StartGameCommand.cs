using Lab4.DB.Service;

namespace Lab4.Commands
{
    internal class StartGameCommand : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        private readonly GameService _gameService;

        public StartGameCommand(GameAccountService gameAccountService, GameService gameService)
        {
            _gameAccountService = gameAccountService;
            _gameService = gameService;
        }
        public void Execute()
        {
            GameAccount player1;
            GameAccount player2;

            Console.WriteLine("Choose players to play game (input their ID`s):");
            int player1ID = int.Parse(Console.ReadLine());
            int player2ID = int.Parse(Console.ReadLine());

            player1 = _gameAccountService.ReadById(player1ID);
            player2 = _gameAccountService.ReadById(player2ID);

            string answer;
            do
            {
                Console.WriteLine("------------------------------------------------");
                Game game = GameType(player1, player2, _gameService);
                game.PlayGame(player1, player2);
                Console.WriteLine("Play again? (Y/N)");
                answer = Console.ReadLine();
            } while (answer.ToUpper() == "Y");
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
