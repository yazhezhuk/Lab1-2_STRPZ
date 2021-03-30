using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Linq;
using System.Linq;
using DAL.Repositories.Abstractions;
using Entities;

namespace DAL.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, ISaveableEntity
    
    {
        private readonly DbSet<TEntity> DataStorage;

        public GenericRepository(DbSet<TEntity> dataStorage)
        {
            DataStorage = dataStorage;
        }
        
        public void Delete(int id)
        {
            var toDelete = DataStorage
                .FirstOrDefault(entity => entity.Id == id);

            DataStorage.ToList().Remove(toDelete);
        }

        public List<TEntity> GetAll() => DataStorage.ToList();
        

        public TEntity GetById(int id)
        {
            return DataStorage
                .FirstOrDefault(entity => entity.Id == id)!;
        }

        public void AddOrUpdate(TEntity obj)
        {
            DataStorage.AddOrUpdate(obj);
        }
    }
}