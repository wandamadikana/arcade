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
    public class PlayerController : ControllerBase
    {
        public IPlayerManager _playerManager { get; set; }
        public PlayerController(IPlayerManager playerManager)
        {
            _playerManager = playerManager;
        }


        #region Player

        // GET api/Player/5
        [HttpGet]
        public async Task<List<Player>> GetAllPlayers()
        {
            var players = await _playerManager.GetAllPlayers();
            return players;
        }

        // GET api/Player/5
        [Route("id")]
        [HttpGet]
        public async Task<Player> GetPlayerId(int id)
        {
            var player = await _playerManager.GetPlayerById(id);
            return player;
        }

        #endregion

    }
}