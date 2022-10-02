using EFPractice.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Repositorys;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;
    private IDbContextTransaction _transaction;
    private IGenericRepository<Category> _CategoryRepository;
    private IGenericRepository<CoverType> _CoverTypeRepository;
    private IGenericRepository<Product> _ProductRepository;
    private bool disposed = false;

    public IGenericRepository<Category> CategoryRepository => _CategoryRepository ?? new CategoryRepository(_context);
    public IGenericRepository<CoverType> CoverTypeRepository => _CoverTypeRepository ?? new CoverTypeRepository(_context);
    public IGenericRepository<Product> ProductRepository => _ProductRepository ?? new ProductRepository(_context);

    public UnitOfWork(DbContext context)
    {
        _context = context;
    }

    public void ManualTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void ExecuteSqlRaw(string sql)
    {
        _context.Database.ExecuteSqlRaw(sql);
    }
}

