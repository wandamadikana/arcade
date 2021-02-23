using Microsoft.EntityFrameworkCore;

namespace Wanda.Games.TicTacToe.Interface.Repository
{
    public interface IDBContextProvider
    {

        DbContext GameDBContext { get; }
    }
}
