using Lab4.DB.Service;

namespace Lab4.Commands
{
    internal class ShowAllGamesCommand : ICommand
    {
        private readonly GameAccountService _gameAccountService;
        public ShowAllGamesCommand(GameAccountService gameAccountService)
        {
            _gameAccountService = gameAccountService;
        }
        public void Execute()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("All games info");
            foreach (GameAccount thisPlayer in _gameAccountService.ReadAll())
            {
                List<GameResult> games = _gameAccountService.GameResults(thisPlayer);
                
                foreach (GameResult game in games)
                {
                    if (thisPlayer.UserName != game.Player)
                    {
                        Console.WriteLine($"Player {game.Player} vs player {game.Opponent}, Player {game.Winner} win, Played for {game.Rating} rating, Game №{game.GameIndex}");
                    }
                }
            }
        }
    }
}
