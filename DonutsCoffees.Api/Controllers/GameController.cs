using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DonutsCoffees.Api.Games;
using DonutsCoffees.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DonutsCoffees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private List<GameSession> gameSession;
        
        public GameController() { }

        public GameController(List<GameSession> gameSession)
        {
            this.gameSession = gameSession;
        }
        
        [HttpGet("[action]")]
        public List<GameSession> GetNewGameSession()
        {
            gameSession = new List<GameSession>();
            return gameSession;
        }
    }
}

