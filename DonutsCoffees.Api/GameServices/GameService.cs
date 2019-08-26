using System;
using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public class GameService : IGameService
    {
        private static GameSession _gameSession;
        private static BoardService _boardService;
        private static IPlayer _player;
        public GameService(GameSession gameSession)
        {
            _gameSession = gameSession;
            _boardService = new BoardService(_gameSession.Board);
            _player = gameSession.PlayerOne;
        }
        
        public GameSession SetupNewGame()
        {
            _player.Token = Token.X.ToString();
            return _gameSession;
        }
        public void UpdateGameSession()
        {
            _boardService.UpdateBoard(_player.RequestedCellPosition, _player.Token);
        }
        
        public void CheckIfGameOver()
        {
            throw new NotImplementedException();
        }
    }
}