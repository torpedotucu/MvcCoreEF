using Microsoft.AspNetCore.Mvc;
using MvcCoreEF.Models;
using MvcCoreEF.Repositories;

namespace MvcCoreEF.Controllers
{
    public class HospitalesController : Controller
    {
        private RepositoryHospital repo;
        public HospitalesController(RepositoryHospital repo)
        {
            this.repo=repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Hospital> hospitals = await this.repo.GetHospitalesAsync();
            return View(hospitals);
        }

        public async Task<IActionResult>Details(int idHospital)
        {
            Hospital hospital =
                await this.repo.FindHospitalAsync(idHospital);
            return View(hospital);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>Create(Hospital hospital)
        {
            await this.repo.InsertHospitalAsync(hospital.IdHospital, hospital.Nombre, hospital.Direccion, hospital.Telefono, hospital.Camas);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult>Delete(int idhospital)
        {
            await this.repo.DeleteHospitalAsync(idhospital);
            return RedirectToAction("Index");
        }
    }
}
