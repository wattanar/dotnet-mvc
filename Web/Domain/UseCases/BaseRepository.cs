using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Data;
using Web.Domain.Repositories;

namespace Web.Domain.UseCases
{
  public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
  {
    protected readonly DataDbContext _dataDbContext;

    public BaseRepository(DataDbContext dataDbContext)
    {
      _dataDbContext = dataDbContext;
    }
    public void Add(TEntity entity)
    {
      _dataDbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
      _dataDbContext.Set<TEntity>().AddRange(entities);
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
      return _dataDbContext.Set<TEntity>().Where(predicate);
    }

    public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
      return _dataDbContext.Set<TEntity>().FirstOrDefault(predicate);
    }

    public IEnumerable<TEntity> GetAll()
    {
      return _dataDbContext.Set<TEntity>().ToList();
    }

    public TEntity GetById(int id)
    {
      return _dataDbContext.Set<TEntity>().Find(id);
    }

    public void Remove(TEntity entity)
    {
      _dataDbContext.Set<TEntity>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
      _dataDbContext.Set<TEntity>().RemoveRange(entities);
    }

    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
      return _dataDbContext.Set<TEntity>().SingleOrDefault(predicate);
    }
  }
}