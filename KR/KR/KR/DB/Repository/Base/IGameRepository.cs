﻿using KR.DB.Entity;

namespace KR.DB.Repository.Base
{
    internal interface IGameRepository
    {
        public void Create(GameEntity gameEntity);
        public List<GameEntity> ReadAll();
        public GameEntity ReadById(int Id);
        public void Update(GameEntity gameEntity);
        public void Delete(GameEntity gameEntity);
    }
}
