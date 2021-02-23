using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wanda.Games.TicTacToe.Interface.Game;
using Wanda.Games.TicTacToe.Interface.Repository;

namespace Wanda.Games.TicTacToe.BLL
{
    public class PlayerManager : IPlayerManager, IDisposable
    {
        private IBaseRepository<Model.DTO.Player> PlayerDetail { get { return GetStandardRepo<Model.DTO.Player>(); } }
        public DbContext GameDbContext { get; set; }
        protected IRepositoryProvider RepositoryProvider { get; set; }
        protected IDBContextProvider DBContextProvider { get; set; }
        protected IMapper mapper { get; set; }


        public PlayerManager(IRepositoryProvider _repositoryProvider, IDBContextProvider _dbContextProvider, IMapper _mapper)
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


        #region Player
        public async Task<List<Model.ViewModel.Player>> GetAllPlayers()
        {
            return mapper.Map<List<Model.ViewModel.Player>>(await PlayerDetail.GetAllAsync());
        }

        public async Task<Model.ViewModel.Player> GetPlayerById(int Id)
        {
            return mapper.Map<Model.ViewModel.Player>(await PlayerDetail.GetByIdAsync(Id));
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
