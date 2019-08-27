using System.Collections.Generic;
using DonutsCoffees.Api.Controllers;
using DonutsCoffees.Api.GameServices;
using DonutsCoffees.Api.Models;
using NUnit.Framework;

namespace DonutsCoffees.Api.Tests.GameServicesTests
{
    [TestFixture]
    public class GameServiceTest
    {
        private Player _player;
        private Board _board;
        private GameSession _testGameSession;
        private GameService _testGameService;
        private BoardService _boardService;

        [SetUp]
        public void Setup()
        {
            _player = new Player(){Token = Token.X.ToString()};
            _board = new Board();
            _testGameSession = new GameSession()
            {
                Board = _board,
                PlayerOne = _player
            };
            _boardService = new BoardService(_testGameSession.Board);
            _testGameService = new GameService(_testGameSession);
        }
        
        [TearDown]
        public void TearDown()
        {
            _board = null;
            _player = null;
        }
        
        [Test]
        public void SetupNewGame_SetsPlayerOneTokenWithX()
        {
            var setGameSession = _testGameService.SetupNewGame();
            
            var resultToken = "X";
            var newGameSession = new GameSession();

            Assert.AreNotEqual(newGameSession, setGameSession);
            Assert.AreEqual(resultToken, setGameSession.PlayerOne.Token);
        }

        [Test]
        public void UpdateGameSession_ReturnsUpdatedBoardWhenPassedValidMove()
        {
            _testGameService.SetupNewGame();
            _player.RequestedCellPosition = 2;
            _testGameService.UpdateGameSession(_player);
            
            var expected = new List<object> {1, "X", 3, 4, 5, 6, 7, 8, 9};
            var expectedStatus = GameStatus.InProgress.ToString();

            Assert.AreEqual(expected, _testGameSession.Board.spaces);
            Assert.AreEqual(expectedStatus, _testGameSession.Status);
        }

        [Test]
        public void UpdateGameSession_ReturnsErrorMessageForInvalidMove()
        {    
            _testGameService.SetupNewGame();
            _player.RequestedCellPosition = 2;
            _testGameService.UpdateGameSession(_player);
            _testGameService.UpdateGameSession(_player);
            
            var expected = GameStatus.PositionSelectionError.ToString();
            
            Assert.AreEqual(expected, _testGameSession.Status);
        }
    }
}