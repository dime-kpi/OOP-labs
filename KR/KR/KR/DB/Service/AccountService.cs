using KR.DB.Entity;
using KR.DB.Repository;
using KR.DB.Service.Base;
using System.Data;

namespace KR.DB.Service
{
    internal class AccountService : IAccountService
    {
        AccountRepository gameAccountRepository;
        public AccountService(DbContext context)
        {
            gameAccountRepository = new AccountRepository(context);
        }

        public void Create(Account entity)
        {
            gameAccountRepository.Create(Map(entity));
        }

        public List<Account> ReadAll()
        {
            return gameAccountRepository.ReadAll().Select(x => x != null ? Map(x) : null).ToList();
        }

        public Account ReadById(int id)
        {
            return Map(gameAccountRepository.ReadById(id));
        }
        public void Update(Account entity)
        {
            gameAccountRepository.Update(Map(entity));
        }

        public void Delete(Account entity)
        {
            gameAccountRepository.Delete(Map(entity));
        }

        public List<GameResult> GameResults(Account entity)
        {
            return MapGameResultList(gameAccountRepository.GameResults(Map(entity)));
        }

        public void AddGameResult(GameResult gameResult, Account entity)
        {
            gameAccountRepository.AddGameResult(MapGameResult(gameResult), Map(entity));
        }

        //Mapers
        private AccountEntity Map(Account account)
        {
            if (account == null)
            {
                return null;
            }
            return new AccountEntity
            {
                Id = account.Id,
                UserName = account.UserName,
                Password = account.Password,
                CurrentRating = account.CurrentRating,
                GamesCount = account.GamesCount,
                GameResults = MapGameResultList(account.GameResults)
            };
        }

        private List<GameResultEntity> MapGameResultList(List<GameResult> gameResultList)
        {
            if (gameResultList == null)
            {
                return null;
            }

            List<GameResultEntity> gameResultEntitieList = new List<GameResultEntity>();

            foreach (var gameResult in gameResultList)
            {
                gameResultEntitieList.Add(new GameResultEntity
                {
                    Player = gameResult.Player,
                    IsWin = gameResult.IsWin,
                    Rating = gameResult.Rating,
                    GameIndex = gameResult.GameIndex
                });
            }
            return gameResultEntitieList;
        }

        private Account Map(AccountEntity account)
        {
            return new Account(this, account.Id, account.UserName, account.Password)
            {
                _service = this,
                UserName = account.UserName,
                CurrentRating = account.CurrentRating,
                GamesCount = account.GamesCount,
                GameResults = MapGameResultList(account.GameResults)
            };
        }
        private List<GameResult> MapGameResultList(List<GameResultEntity> gameResultEntitieList)
        {
            List<GameResult> gameResultList = new List<GameResult>();
            if (gameResultEntitieList == null)
            {
                return new List<GameResult>();
            }
            foreach (var gameResultEntity in gameResultEntitieList)
            {
                gameResultList.Add(new GameResult
                {
                    Player = gameResultEntity.Player,
                    IsWin = gameResultEntity.IsWin,
                    Rating = gameResultEntity.Rating,
                    GameIndex = gameResultEntity.GameIndex
                });
            }
            return gameResultList;
        }

        private GameResultEntity MapGameResult(GameResult gameResult)
        {
            if (gameResult == null)
            {
                return null;
            }

            return new GameResultEntity
            {
                Player = gameResult.Player,
                IsWin = gameResult.IsWin,
                Rating = gameResult.Rating,
                GameIndex = gameResult.GameIndex
            };
        }
    }
}
