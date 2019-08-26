using DonutsCoffees.Api.Controllers;
using DonutsCoffees.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace DonutsCoffees.Api.Tests.ControllersTests
{
    [TestFixture]
    public class GameControllerTest
    {
        private GameController _controller;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _controller = new GameController();
            _player= new Player();
        }
        
        [Test]
        public void GetGameSession_ItSendsNewGameSessionToClient()
        {
            var result = _controller.GetGameSession();

            Assert.IsInstanceOf<GameSession>(result);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateMove_RedirectsToGetGameSessionAction()
        {
            _player.Token = Token.O.ToString();
            _player.RequestedCellPosition = 5;
            
            var result = _controller.CreateMove(_player);
            var actionResult = result as RedirectToActionResult;
                
            Assert.IsNotNull(actionResult);
            Assert.AreEqual("GetGameSession", actionResult.ActionName);
        }
    }
}