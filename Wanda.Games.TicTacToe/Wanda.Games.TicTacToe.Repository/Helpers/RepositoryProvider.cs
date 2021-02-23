﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Wanda.Games.TicTacToe.Interface.Repository;

namespace Wanda.Games.TicTacToe.Repository.Helpers
{
    public class RepositoryProvider : IRepositoryProvider
    {

        public DbContext DbContext { get; set; }

        protected Dictionary<Type, object> Repositories { get; private set; }

        private RepositoryFactory _repositoryFactories;

        public RepositoryProvider(RepositoryFactory repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        public IBaseRepository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<IBaseRepository<T>>(
                _repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<DbContext, object> factory = null) where T : class
        {
            // Look for T dictionary cache under typeof(T).
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }

            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }


        protected virtual T MakeRepository<T>(Func<DbContext, object> factory, DbContext DbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException("No factory for repository type, " + typeof(T).FullName);
            }
            var repo = (T)f(DbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }


    }
}
