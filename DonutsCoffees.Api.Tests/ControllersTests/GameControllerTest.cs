using System;
using System.Collections.Generic;
using System.Net.Http;
using DonutsCoffees.Api.Controllers;
using DonutsCoffees.Api.GameServices;
using DonutsCoffees.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace DonutsCoffees.Api.Tests.ControllersTests
{
    [TestFixture]
    public class GameControllerTest
    {
        private GameController _controller;
        private Player _player;
        private GameSession _gameSession;
        private GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _controller = new GameController();
            _player= new Player();
            _gameSession = new GameSession();
            _gameService = new GameService(_gameSession);
        }
        
        [Test]
        public void GetNewGameSession_ItSendsNewGameSessionToClient()
        {
            var result = _controller.GetNewGameSession();
            var expectedBoardSpaceCount = 9;
            
            Assert.IsInstanceOf<GameSession>(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedBoardSpaceCount, result.Board.spaces.Count);
            Assert.False(result.Board.spaces.Contains(typeof(string)));
        }

        [Test]
        public void GetGameSession_ItGetsCurrentGameSession()
        {
            _controller.GetNewGameSession();
           
            _player.RequestedCellPosition = 5;
            _controller.CreateMove(_player);
            var result = _controller.GetGameSession();
            var expectedBoardSpaceCount = 9;

            Assert.IsInstanceOf<GameSession>(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedBoardSpaceCount, result.Board.spaces.Count);
        }
        
        [Test]
        public void CreateMove_RedirectsToGetGameSessionAction()
        {
            _controller.GetNewGameSession();
           
            _player.RequestedCellPosition = 5;
            _controller.CreateMove(_player);
            
            var result = _controller.CreateMove(_player);
            var actionResult = result as RedirectToActionResult;
                
            Assert.IsNotNull(actionResult);
            Assert.AreEqual("GetGameSession", actionResult.ActionName);
        }

//        [Test]
//        public void HandleMoveRequestError_ReturnsBadRequestResponseAfterReceivingInvalidMove()
//        {
//            _controller.GetNewGameSession();
//            _player.RequestedCellPosition = 5;
//            _controller.CreateMove(_player);
//            _player.RequestedCellPosition = 5;
//
//            var result = HandleMoveRequestError(_player);
//            var expectedMessage = GameStatus.PositionSelectionError.ToString();
//            
//            
//            Assert.IsNotNull(ActionResult);
//            Assert.IsInstanceOf(result, typeof(RedirectToActionResult));
//            Assert.AreEqual(expectedMessage, );
//        }
    }
}