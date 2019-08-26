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
        private IPlayer _player;
        private Board _board;
        private GameSession _testGameSession;
        private GameService _testGameService;
        private BoardService _boardService;

        [SetUp]
        public void Setup()
        {
            _player = new Player();
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
        public void UpdateGameSession_ReturnsUpdatedBoard()
        {
            _testGameService.SetupNewGame();
            _player.RequestedCellPosition = 2;
            _testGameService.UpdateGameSession();
            
            var expected = new List<object> {1, "X", 3, 4, 5, 6, 7, 8, 9};

            Assert.AreEqual(expected, _testGameSession.Board.spaces);
        }
    }
}