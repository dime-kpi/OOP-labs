using KR.DB.Entity;
using KR.DB.Repository;
using KR.DB.Service.Base;

namespace KR.DB.Service
{
    internal class GameService : IGameService
    {
        GameRepository gameRepository;
        public GameService(DbContext context)
        {
            gameRepository = new GameRepository(context);
        }

        public void Create(Game gameEntity)
        {
            gameRepository.Create(Map(gameEntity));
        }

        public void Update(Game gameEntity)
        {
            gameRepository.Update(Map(gameEntity));
        }

        public void Delete(Game gameEntity)
        {
            gameRepository.Delete(Map(gameEntity));
        }

        //Mapers
        private GameEntity Map(Game game)
        {
            return new GameEntity
            {
                Player = game.player,
                PlayRating = game.playRating,
                IsWin = game.isWin,
            };
        }
    }
}
