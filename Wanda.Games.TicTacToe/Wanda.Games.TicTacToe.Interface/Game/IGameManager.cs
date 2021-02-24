using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanda.Games.TicTacToe.Model;

namespace Wanda.Games.TicTacToe.Interface.Game
{
    public interface IGameManager
    {
        Task<List<Model.ViewModel.Game>> GetAllGames();
        Task<Model.ViewModel.Game> GetGameById(int id);
        Task<int> AddGame(Model.ViewModel.Game game);
        Task UpdateGame(Model.ViewModel.Game game);
        Task DeleteGame(int Id);
    }
}
