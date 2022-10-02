using EFPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Repositorys;

public class ProductRepository : GenericRepository<Product>
{
    public ProductRepository(DbContext context) : base(context)
    {
    }
}

