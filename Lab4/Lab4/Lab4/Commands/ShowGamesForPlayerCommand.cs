using Lab4.DB.Service;

namespace Lab4.Commands
{
    internal class ShowGamesForPlayerCommand : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowGamesForPlayerCommand(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }
        public void Execute()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Input player ID:");
            int playerID = int.Parse(Console.ReadLine());
            GameAccount player = _gameAccountService.ReadById(playerID);
            Console.WriteLine($"Info about games of player {player.UserName}:");
            List<GameResult> games = _gameAccountService.GameResults(player);
            foreach (GameResult game in games)
            {
                Console.WriteLine($"Player {game.Player} vs player {game.Opponent}, Player {game.Winner} win, Played for {game.Rating} rating, Game №{game.GameIndex}");
            }
        }
    }
}
