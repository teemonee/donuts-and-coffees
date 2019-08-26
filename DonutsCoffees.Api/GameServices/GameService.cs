using System;
using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public class GameService : IGameService
    {
        private static GameSession _gameSession;
        
        public GameService(GameSession gameSession)
        {
            _gameSession = gameSession;
        }
        
        public GameSession SetupNewGame()
        {
            _gameSession.PlayerOne.Token = Token.X.ToString();
            return _gameSession;
        }
        public void UpdateGameSession(GameSession gameSession)
        {
            throw new NotImplementedException();
        }
        
        public void CheckIfGameOver(GameSession gameSession)
        {
            throw new NotImplementedException();
        }
    }
}