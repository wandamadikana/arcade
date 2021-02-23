using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wanda.Games.TicTacToe.Interface.Repository;

namespace Wanda.Games.TicTacToe.Repository
{
    public class BaseRepository<TEntityType> : IBaseRepository<TEntityType> where TEntityType : class
    {

        public DbContext dbDilatedTechContext { get; set; }
        public DbSet<TEntityType> dbDilatedTechSet { get; set; }

        public BaseRepository(DbContext dbpmContext)
        {
            if (dbpmContext == null)
                throw new ArgumentNullException("dbGameContext");

            dbDilatedTechContext = dbpmContext;
            dbDilatedTechSet = dbpmContext.Set<TEntityType>();
        }

        public virtual void Add(TEntityType entity)
        {
            dbDilatedTechContext.Set<TEntityType>().Add(entity);
            dbDilatedTechContext.SaveChanges();
        }

        public virtual void Delete(TEntityType entity)
        {
            dbDilatedTechContext.Set<TEntityType>().Remove(entity);
            dbDilatedTechContext.SaveChanges();
        }

        public virtual void Update(TEntityType entity)
        {
            dbDilatedTechContext.Entry(entity).State = EntityState.Modified;
            dbDilatedTechContext.SaveChanges();
        }
        public virtual List<TEntityType> GetItems(Expression<Func<TEntityType, bool>> filter)
        {
            return this.dbDilatedTechSet.Where(filter).ToList();
        }

        public virtual TEntityType Get(Expression<Func<TEntityType, bool>> filter)
        {
            return this.dbDilatedTechSet.SingleOrDefault(filter);
        }
        public virtual TEntityType GetById(int id)
        {
            return dbDilatedTechSet.Find(id);
        }

        public virtual List<TEntityType> GetAll()
        {
            return dbDilatedTechSet.ToList();
        }

        public virtual async Task<int> AddAsync(TEntityType entity)
        {
            dbDilatedTechContext.Set<TEntityType>().Add(entity);
            return await dbDilatedTechContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntityType entity)
        {
            dbDilatedTechContext.Set<TEntityType>().Remove(entity);
            await dbDilatedTechContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntityType entity)
        {
            dbDilatedTechContext.Entry(entity).State = EntityState.Modified;
            await dbDilatedTechContext.SaveChangesAsync();

        }
        public virtual async Task<List<TEntityType>> GetItemsAsync(Expression<Func<TEntityType, bool>> filter)
        {
            return await this.dbDilatedTechSet.Where(filter).ToListAsync();
        }

        public virtual async Task<TEntityType> GetAsync(Expression<Func<TEntityType, bool>> filter)
        {
            return await this.dbDilatedTechSet.FirstOrDefaultAsync(filter);
        }
        public virtual async Task<TEntityType> GetByIdAsync(int id)
        {
            return await dbDilatedTechSet.FindAsync(id);
        }

        public virtual async Task<List<TEntityType>> GetAllAsync()
        {
            return await dbDilatedTechSet.ToListAsync();
        }
    }
}
