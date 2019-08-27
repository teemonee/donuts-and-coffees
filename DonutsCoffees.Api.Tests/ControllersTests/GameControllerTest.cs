using System;
using System.Collections.Generic;
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

            Assert.IsInstanceOf<GameSession>(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(9, result.Board.spaces.Count);
            Assert.False(result.Board.spaces.Contains(typeof(string)));
        }

        [Test]
        public void GetGameSession_ItGetsCurrentGameSession()
        {
            _controller.GetNewGameSession();
           
            _player.RequestedCellPosition = 5;
            _controller.CreateMove(_player);
            var result = _controller.GetGameSession();

            Assert.IsInstanceOf<GameSession>(result);
            Assert.IsNotNull(result);
            Assert.AreEqual(9, result.Board.spaces.Count);
        }
        
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
    }
}