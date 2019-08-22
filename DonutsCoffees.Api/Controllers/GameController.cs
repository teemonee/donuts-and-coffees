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
        private List<GameSession> _gameSession;

        [HttpGet("[action]")]
        public List<GameSession> GetNewGameSession()
        {
            _gameSession = new List<GameSession> {new GameSession {Board = new Board()}};
            return _gameSession;
        }
    }
}

