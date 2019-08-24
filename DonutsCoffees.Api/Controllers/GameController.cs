using System.Collections.Generic;
using System.Data.Common;
using DonutsCoffees.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DonutsCoffees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private GameSession _gameSession = new GameSession();

        [HttpGet("[action]")]
        public GameSession GetNewGameSession()
        {
            _gameSession.Board = new Board();
            return _gameSession;
        }
    }
}

