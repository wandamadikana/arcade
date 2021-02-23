using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wanda.Games.TicTacToe.Interface.Repository
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }
        IBaseRepository<T> GetRepositoryForEntityType<T>() where T : class;
        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;
        void SetRepository<T>(T repository);
    }
}
