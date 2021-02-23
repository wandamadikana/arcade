using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Wanda.Games.TicTacToe.Interface.Repository
{
    public interface IBaseRepository<TEntityType> where TEntityType : class
    {
        void Add(TEntityType entity);
        void Delete(TEntityType entity);
        void Update(TEntityType entity);
        List<TEntityType> GetItems(Expression<Func<TEntityType, bool>> filter);
        TEntityType Get(Expression<Func<TEntityType, bool>> filter);
        TEntityType GetById(int id);
        List<TEntityType> GetAll();
        Task<int> AddAsync(TEntityType entity);
        Task DeleteAsync(TEntityType entity);
        Task UpdateAsync(TEntityType entity);
        Task<List<TEntityType>> GetItemsAsync(Expression<Func<TEntityType, bool>> filter);
        Task<TEntityType> GetAsync(Expression<Func<TEntityType, bool>> filter);
        Task<TEntityType> GetByIdAsync(int id);
        Task<List<TEntityType>> GetAllAsync();
    }
}
