using FRDZ_School_Web.Data;
using FRDZ_School_Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ApplicationContext _db;
        public TeacherController(ApplicationContext db) => _db = db;

        public IActionResult Index()
        {
            IEnumerable<Teacher> objTeacherList = _db.Teacher.ToList();
            return View(objTeacherList);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
