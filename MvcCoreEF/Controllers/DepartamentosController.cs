using Microsoft.AspNetCore.Mvc;
using MvcCoreEF.Models;
using MvcCoreEF.Repositories;

namespace MvcCoreEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamento repo;
        public DepartamentosController(RepositoryDepartamento repo)
        {
            this.repo=repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos =await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }
        public async Task<IActionResult>Details(int idDept)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(idDept);
            return View(dept);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Departamento dept)
        {
            await this.repo.InsertDepartamentoAsync(dept.Dept_no, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult>Edit(int idDept)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(idDept);
            return View(dept);
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Departamento dept)
        {
            await this.repo.UpdateDepartamentosAsync(dept.Dept_no, dept.Nombre, dept.Localidad);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult>Delete(int idDept)
        {
            await this.repo.DeleteDepartamentoAsync(idDept);
            return RedirectToAction("Index");
        }
    }
}
