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
            _playerOne = _gameSession.PlayerOne = new Player();
            _playerTwo = _gameSession.PlayerTwo = new Player();
        }
        
        public GameSession SetupNewGame()
        {
            _playerOne.Token = Token.X.ToString();
            _playerTwo.Token = Token.O.ToString();
            _currentPlayer = _playerOne;
            return _gameSession;
        }

        public Player SwitchPlayer()
        {
            var currentPlayer = _currentPlayer == _playerOne ? _playerTwo : _playerOne;
            return currentPlayer;
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