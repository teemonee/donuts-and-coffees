using System;
using DonutsCoffees.Api.GameServices;
using DonutsCoffees.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DonutsCoffees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static GameSession _gameSession = new GameSession();
        private static GameService _gameService = new GameService(_gameSession);

        [HttpGet("[action]")]
        public GameSession GetNewGameSession()
        {
            return _gameService.SetupNewGame();
        }
        
        [HttpGet("[action]")]
        public GameSession GetGameSession()
        {
            return _gameSession;
        }

        [HttpPost("[action]")]
        public IActionResult CreateMove([FromBody]Player incomingItem)
        {
            _gameService.UpdateGameSession(incomingItem);

            return RedirectToAction("GetGameSession");
        }
    }
}

