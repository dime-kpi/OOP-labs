using KR.DB.Entity;

namespace KR.DB.Repository.Base
{
    internal interface IAccountRepository
    {
        public void Create(AccountEntity entity);
        public List<AccountEntity> ReadAll();
        public AccountEntity ReadById(int id);
        public void Update(AccountEntity entity);
        public void Delete(AccountEntity entity);
        public List<GameResultEntity> GameResults(AccountEntity entity);
        public void AddGameResult(GameResultEntity gameResult, AccountEntity entity);
    }
}