using System;
using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public class GameService : IGameService
    {
        private static GameSession _gameSession;
        private static BoardService _boardService;
        private static Player _player;
        
        public GameService(GameSession gameSession)
        {
            _gameSession = gameSession;
            _gameSession.Board = new Board();
            _boardService = new BoardService(_gameSession.Board);
            _player = new Player();
        }
        
        public GameSession SetupNewGame()
        {
            _player.Token = Token.X.ToString();
            return _gameSession;
        }
        
        public void UpdateGameSession(Player incomingItem)
        {
            _boardService.UpdateBoard(incomingItem.RequestedCellPosition, _player.Token);
        }
        
        public void CheckIfGameOver()
        {
            throw new NotImplementedException();
        }
    }
}