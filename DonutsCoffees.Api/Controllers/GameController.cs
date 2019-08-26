using DonutsCoffees.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DonutsCoffees.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static GameSession _gameSession = new GameSession();
        private static IPlayer _playerOne = new Player();
        private static Board _board = new Board();

        [HttpGet("[action]")]
        public GameSession GetGameSession()
        {
            _gameSession.Board = _board;
            return _gameSession;
        }

        [HttpPost("[action]")]
        public IActionResult CreateMove([FromBody]Player incomingItem)
        {
            _gameSession.PlayerOne = _playerOne;
            _playerOne.RequestedCellPosition = incomingItem.RequestedCellPosition;
            _playerOne.Token = Token.O.ToString();

            _board.spaces[incomingItem.RequestedCellPosition - 1] = _playerOne.Token;

            _playerOne.Token = Token.X.ToString();

            return RedirectToAction("GetGameSession");
        }
    }
}

