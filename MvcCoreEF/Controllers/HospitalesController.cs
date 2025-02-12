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
    }
}
