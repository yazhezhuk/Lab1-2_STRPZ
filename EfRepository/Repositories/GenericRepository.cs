using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EfRepository.Abstractions;
using Entities;
using MiscUtil.Reflection;

namespace EfRepository.Repositories
{
	public class GenericRepository<TEntity> : IRepository<TEntity>
		where TEntity : class, IEntity

	{
		private readonly ShopContext _dataContext;
		private readonly DbSet<TEntity> _dataTable;


		public GenericRepository(ShopContext dataContext, DbSet<TEntity> dataTable)
		{

			_dataTable = dataTable;
			_dataContext = dataContext;
		}

		public void Delete(TEntity entity)
		{
			_dataContext.Entry(entity).State = EntityState.Unchanged;
			_dataTable.Attach(entity);

			_dataTable.Remove(entity);
		}

		public List<TEntity> GetAll() => _dataTable.ToList();


		public TEntity GetById(int id) =>
			_dataTable.FirstOrDefault(entity => entity.Id == id);

		public void AddOrUpdate(TEntity obj) {
			_dataTable.AddOrUpdate(obj);
			_dataContext.SaveChanges();
		}
		
		public void Add(TEntity obj) {
			_dataTable.Add(obj);
			_dataContext.SaveChanges();
		}

		public virtual void Update(TEntity obj)
		{
			TEntity entity = _dataTable.Find(obj.Id);
			_dataContext.Entry(entity)?.CurrentValues.SetValues(obj);
			_dataContext.SaveChanges();
		}
	}
}