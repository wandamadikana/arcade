using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wanda.Games.TicTacToe.DAL;
using Wanda.Games.TicTacToe.Interface.Repository;

namespace Wanda.Games.TicTacToe.Repository.Helpers
{
    public class DBContextProvider : IDBContextProvider
    {
        private DbContext gamedbcontext;

        public DBContextProvider() { }

        public DbContext GameDBContext
        {
            get
            {
                if (gamedbcontext == null)
                {
                    gamedbcontext = new GameDbContext();
                }
                return gamedbcontext;
            }
        }

    }
}
