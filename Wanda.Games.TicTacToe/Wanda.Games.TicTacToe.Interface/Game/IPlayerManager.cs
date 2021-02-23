using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanda.Games.TicTacToe.Model;

namespace Wanda.Games.TicTacToe.Interface.Game
{
    public interface IPlayerManager
    {
        Task<List<Model.ViewModel.Player>> GetAllPlayers();
        Task<Model.ViewModel.Player> GetPlayerById(int id);
    }
}
