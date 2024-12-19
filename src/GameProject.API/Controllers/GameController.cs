using Microsoft.AspNetCore.Mvc;
using GameProject.API.Models;
using GameProject.API.Services;

namespace GameProject.API.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet("board")]
        public IActionResult GetBoard() => Ok(_gameService.GetBoard());

        [HttpGet("players")]
        public IActionResult GetPlayers() => Ok(_gameService.GetPlayers());

        [HttpPost("move/{playerId}")]
        public IActionResult MovePlayer(int playerId, [FromBody] int steps)
        {
            var player = _gameService.MovePlayer(playerId, steps);
            return Ok(player);
        }

        [HttpGet("status")]
        public IActionResult GetGameStatus()
        {
            return Ok(new
            {
                IsGameOver = _gameService.IsGameOver(),
                Players = _gameService.GetPlayers()
            });
        }
    }
}
