using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryDepartamento
    {
        private DepartamentoContext context;
        
        public RepositoryDepartamento(DepartamentoContext context)
        {
            this.context=context;
        }
        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return await consulta.ToListAsync();
        }
        public async Task<Departamento>FindDepartamentoAsync(int idDept)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.Dept_no==idDept
                           select datos;
            if (consulta.Count()==0)
            {
                return null;
            }
            else
            {
                return await consulta.FirstAsync();
            }
        }

        public async Task InsertDepartamentoAsync(int idDept, string nombre, string localidad)
        {
            Departamento dept;
            dept.Dept_no=idDept;
            dept.Nombre=nombre;
            dept.Localidad=localidad;

            await this.context.Departamentos.AddAsync(dept);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDepartamentosAsync
            (int idDept,string nombre, string localidad)
        {
            Departamento dept = await this.FindDepartamentoAsync(idDept);
            dept.Nombre=nombre;
            dept.Localidad=localidad;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDepartamentoAsync(int idDept)
        {
            Departamento dept = await this.FindDepartamentoAsync(idDept);
            this.context.Departamentos.Remove(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
