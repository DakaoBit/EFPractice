using EFPractice.Models;

namespace EFPractice.Repositorys;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Category> CategoryRepository { get; }
    IGenericRepository<CoverType> CoverTypeRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }

    void Save();

    Task SaveAsync();

    void Commit();

    void ManualTransaction();

    void ExecuteSqlRaw(string sql);
}

