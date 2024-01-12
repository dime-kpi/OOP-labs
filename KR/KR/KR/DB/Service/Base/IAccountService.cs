
namespace KR.DB.Service.Base
{
    internal interface IAccountService
    {
        public void Create(Account entity);
        public List<Account> ReadAll();
        public Account ReadById(int id);
        public void Update(Account entity);
        public void Delete(Account entity);
        public List<GameResult> GameResults(Account entity);
        public void AddGameResult(GameResult gameResult, Account entity);
    }
}
