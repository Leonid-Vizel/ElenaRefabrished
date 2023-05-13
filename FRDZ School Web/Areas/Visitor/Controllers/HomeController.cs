using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FRDZ_School_Web.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class HomeController : Controller
    {
        private readonly ITeacherUnitOfWork _unitOfWork;
        public HomeController(ITeacherUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TeacherPage()
        {
            IEnumerable<Teacher> objTeacherList = await _unitOfWork.Teacher.GetAllAsync();
            return View(objTeacherList);
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Conditions()
        {
            return View();
        }

        public IActionResult Requisites()
        {
            return View();
        }

        public IActionResult HealthAndFood()
        {
            return View();
        }

        public IActionResult Regime()
        {
            return View();
        }

        public IActionResult Location()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}