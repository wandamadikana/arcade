using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanda.Games.TicTacToe.Interface.Game;
using Wanda.Games.TicTacToe.Interface.Repository;

namespace Wanda.Games.TicTacToe.BLL
{
    public class GameManager : IGameManager, IDisposable
    {
        private IBaseRepository<Model.DTO.Game> GameDetail { get { return GetStandardRepo<Model.DTO.Game>(); } }
        private IBaseRepository<Model.DTO.Move> MoveDetail { get { return GetStandardRepo<Model.DTO.Move>(); } }
        public DbContext GameDbContext { get; set; }
        protected IRepositoryProvider RepositoryProvider { get; set; }
        protected IDBContextProvider DBContextProvider { get; set; }
        protected IMapper mapper { get; set; }


        public GameManager(IRepositoryProvider _repositoryProvider, IDBContextProvider _dbContextProvider, IMapper _mapper)
        {
            CreateDbContext(_dbContextProvider);
            _repositoryProvider.DbContext = GameDbContext;
            RepositoryProvider = _repositoryProvider;
            mapper = _mapper;
        }

        private void CreateDbContext(IDBContextProvider _dbContextProvider)
        {
            GameDbContext = _dbContextProvider.GameDBContext;
        }

        private IBaseRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }


        #region Game
        public async Task<List<Model.ViewModel.Game>> GetAllGames()
        {
            return mapper.Map<List<Model.ViewModel.Game>>(await GameDetail.GetAllAsync());
        }

        public async Task<Model.ViewModel.Game> GetGameById(int Id)
        {
            return mapper.Map<Model.ViewModel.Game>(await GameDetail.GetByIdAsync(Id));
        }
        public async Task<int> AddGame(Model.ViewModel.Game game)
        {
            await GameDetail.AddAsync(mapper.Map<Model.DTO.Game>(game));
            var entity = await GameDetail.GetItemsAsync(a => a.GameName == game.GameName);
            return entity.FirstOrDefault().Id;
        }
        public async Task UpdateGame(Model.ViewModel.Game game)
        {
            await GameDetail.UpdateAsync(mapper.Map<Model.DTO.Game>(game));
        }
        public async Task DeleteGame(int ID)
        {
            var entity = await GameDetail.GetByIdAsync(ID);
            await GameDetail.DeleteAsync(mapper.Map<Model.DTO.Game>(entity));
        }

        #endregion

        #region Moves
        public async Task AddMoves(List<Model.ViewModel.Move> moveItems)
        {
            foreach (var item in moveItems)
            {
                await MoveDetail.AddAsync(mapper.Map<Model.DTO.Move>(item));
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                if (GameDbContext != null)
                    GameDbContext.Dispose();
        }

        #endregion
    }
}
