using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wanda.Games.TicTacToe.Repository.Helpers
{
    public class RepositoryFactory
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;
        public RepositoryFactory()
        {
            _repositoryFactories = new Dictionary<Type, Func<DbContext, object>>();
        }
        public RepositoryFactory(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return DbContext => new BaseRepository<T>(DbContext);
        }

    }
}
