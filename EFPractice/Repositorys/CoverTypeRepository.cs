using EFPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Repositorys;

public class CoverTypeRepository : GenericRepository<CoverType>
{
    public CoverTypeRepository(DbContext context) : base(context)
    {
    }
}
