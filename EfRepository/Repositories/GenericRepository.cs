using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EfRepository.Abstractions;
using Entities;

namespace EfRepository.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class,IEntity 
    
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


        public TEntity GetById(int id) => 
            DataStorage.FirstOrDefault(entity => entity.Id == id);

        public void AddOrUpdate(TEntity obj) =>
            DataStorage.AddOrUpdate(obj);
    }
}