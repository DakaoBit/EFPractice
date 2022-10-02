using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFPractice.Repositorys;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    internal DbContext _context;
    internal DbSet<TEntity> dbSet;

    public GenericRepository(DbContext context)
    {
        this._context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;
     
        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return query;
    }

    public virtual TEntity GetByID(object id)
    {
        return dbSet.Find(id);
    }

    public virtual TEntity GetByIDNoTracking(object id)
    {
        var _entity = dbSet.Find(id);

        if (_entity != null)
        {
            _context.Entry(_entity).State = EntityState.Detached;
        }

        return _entity;
    }

    public virtual void Insert(TEntity entity)
    {
        dbSet.Add(entity);       
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);        
    }

    public virtual void InsertRange(IEnumerable<TEntity> entities)
    {
        dbSet.AddRange(entities);
    }

    public virtual async Task InsertRangeAsync(IEnumerable<TEntity> entities)
    {
        await dbSet.AddRangeAsync(entities);     
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        _context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual void Delete(object id)
    {
        TEntity entityToDelete = dbSet.Find(id);
        Delete(entityToDelete);
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }
        dbSet.Remove(entityToDelete);
    }

    public virtual void DeleteRange(IEnumerable<TEntity> entitiesToDelete)
    {
        dbSet.RemoveRange(entitiesToDelete);
    }
}
