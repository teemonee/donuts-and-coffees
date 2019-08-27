using System;
using DonutsCoffees.Api.Models;

namespace DonutsCoffees.Api.GameServices
{
    public class GameService : IGameService
    {
        private static GameSession _gameSession;
        private static BoardService _boardService;
        private static Player _playerOne;
        private static Player _playerTwo;
        private static Player _currentPlayer;

        public GameService(GameSession gameSession)
        {
            _gameSession = gameSession;
            _gameSession.Board = new Board();
            _boardService = new BoardService(_gameSession.Board);
            _playerOne = _gameSession.PlayerOne = new Player() {Token = Token.X.ToString()};
            _playerTwo = _gameSession.PlayerTwo = new Player() { Token = Token.O.ToString()};
        }
        
        public GameSession SetupNewGame()
        {
            _currentPlayer = _playerOne;
            return _gameSession;
        }

        public Player SwitchPlayer()
        {
            return _currentPlayer == _playerOne ? _playerTwo : _playerOne;
        }

        public bool MoveValidationSuccess(Player incomingItem)
        {
            return _boardService.IsValidMove(incomingItem.RequestedCellPosition);
        }

        public void UpdateGameSession(Player incomingItem)
        {
            _boardService.UpdateBoard(incomingItem.RequestedCellPosition, _currentPlayer.Token);
            _currentPlayer = SwitchPlayer();
            _gameSession.Status = GameStatus.InProgress.ToString();
        }
        
        public void CheckIfGameOver()
        {
            throw new NotImplementedException();
        }
    }
}