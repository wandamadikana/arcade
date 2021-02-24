using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wanda.Games.TicTacToe.Interface.Game;
using Wanda.Games.TicTacToe.Model.ViewModel;

namespace Wanda.Games.TicTacToe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        public IGameManager _gameManager { get; set; }
        public GameController(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }


        #region Game

        // GET api/Game/5
        [Route("all")]
        [HttpGet]
        public async Task<List<Game>> GetAllGames()
        {
            var games = await _gameManager.GetAllGames();
            return games;
        }

        // GET api/Game/5
        [Route("id")]
        [HttpGet]
        public async Task<Game> GetGameId(int id)
        {
            var game = await _gameManager.GetGameById(id);
            return game;
        }

        // POST api/game
        [HttpPost]
        public async Task<int> GamePost([FromBody]Game game)
        {
           return await _gameManager.AddGame(game);
        }

        [HttpPut]
        public async Task GamePut([FromBody] Game game)
        {
            await _gameManager.UpdateGame(game);
        }

        // DELETE api/Game/5
        [Route("delete")]
        [HttpDelete]
        public async Task GameDelete(int id)
        {
            await _gameManager.DeleteGame(id);
        }

        #endregion

    }
}