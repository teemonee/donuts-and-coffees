using System;
using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public class GameService : IGameService
    {
        public GameSession SetupNewGame()
        {   
            return new GameSession();
        }

        public void CheckIfGameOver(GameSession gameSession)
        {
            throw new NotImplementedException();
        }

        public void UpdateGameSession(GameSession gameSession)
        {
            throw new NotImplementedException();
        }
    }
}