using EFPractice.Models;
using Microsoft.EntityFrameworkCore;
using EFPractice.Models;

namespace EFPractice.Repositorys;

public class CategoryRepository : GenericRepository<Category>
{
    public CategoryRepository(DbContext context) : base(context)
    {
    } 
}

