using System.Linq.Expressions;

namespace EFPractice.Repositorys;

public interface IGenericRepository<TEntity> where TEntity : class
{
    IQueryable<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "");
        
    TEntity GetByID(object id);

    TEntity GetByIDNoTracking(object id);

    void Insert(TEntity entity);

    Task InsertAsync(TEntity entity);

    void InsertRange(IEnumerable<TEntity> entities);

    Task InsertRangeAsync(IEnumerable<TEntity> entities);

    void Delete(object id);

    void Delete(TEntity entityToDelete);

    void DeleteRange(IEnumerable<TEntity> entitiesToDelete);

    void Update(TEntity entityToUpdate);
}

