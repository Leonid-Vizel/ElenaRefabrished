using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FRDZ_School_Web.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TeacherPage()
        {
            IEnumerable<Teacher> objTeacherList = _unitOfWork.Teacher.GetAll().ToList();
            return View(objTeacherList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}