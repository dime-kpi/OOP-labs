
namespace KR.DB.Entity
{
    internal class GameEntity
    {
        public int Id { get; set; }
        public Account Player { get; set; }
        public int PlayRating { get; set; }
        public string IsWin { get; set; }
    }
}