using Lab4.DB.Service;

namespace Lab4.Commands
{
    internal class ShowAllPlayersCommand : ICommand
    {
        private readonly GameAccountService _service;
        public ShowAllPlayersCommand(GameAccountService service)
        {
            _service = service;
        }

        public void Execute()
        {
            Console.WriteLine("------------------------------------------------");
            List<GameAccount> playersList = _service.ReadAll();
            foreach (GameAccount player in playersList)
            {
                ShowPlayer(player);
            }
        }

        private void ShowPlayer(GameAccount player)
        {
            Console.WriteLine($"Player ID: {player.Id}, name: {player.UserName}, current rating: {player.CurrentRating}");
        }
    }
}
