using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class DepartamentoContext:DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options)
            :base(options)
        { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
