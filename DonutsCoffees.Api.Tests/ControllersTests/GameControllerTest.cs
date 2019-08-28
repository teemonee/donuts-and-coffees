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
        private Player _playerOne;
        private Player _playerTwo;
        private GameSession _gameSession;
        private GameService _gameService;

        [SetUp]
        public void Setup()
        {
            _controller = new GameController();
            _playerOne = new Player();
            _playerTwo = new Player();
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
            _playerOne.RequestedCellPosition = 5;
            _controller.CreateMove(_playerOne);
           
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
            _playerOne.RequestedCellPosition = 5;

            var result = _controller.CreateMove(_playerOne) as RedirectToActionResult;

            var actionName = "GetGameSession";
            Assert.IsNotNull(result);
            Assert.AreEqual(actionName, result.ActionName);
        }

        [Test]
        public void CreateMove_RedirectsToGetGameSessionAfterReceivingInvalidMove()
        {
            _controller.GetNewGameSession();
            _playerOne.RequestedCellPosition = 5;
            _controller.CreateMove(_playerOne);
            _playerTwo.RequestedCellPosition = 5;

            var result = _controller.CreateMove(_playerTwo) as RedirectToActionResult;
            
            var actionName = "GetGameSession";
            Assert.IsNotNull(result);
            Assert.AreEqual(actionName, result.ActionName);
        }

    }
}