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
            _testGameService = new GameService(_testGameSession);
        }
        
        [TearDown]
        public void TearDown()
        {
            _board = null;
            _player = null;
        }
        
        [Test]
        public void SetupNewGame_ShouldReturnSetPlayerOneTokenWithX()
        {
            var setGameSession = _testGameService.SetupNewGame();
            
            var resultToken = "X";
            var newGameSession = new GameSession();

            Assert.AreNotEqual(newGameSession, setGameSession);
            Assert.AreEqual(resultToken, setGameSession.PlayerOne.Token);
        }
    }
}