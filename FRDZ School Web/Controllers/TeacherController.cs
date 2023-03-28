using FRDZSchool.DataAccess;
using FRDZSchool.DataAccess.Data;
using FRDZSchool.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _db.Teacher.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Учитель добавлен!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var teacherFromDb = _db.Teacher.Find(Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }

            return View(teacherFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher obj)
        {
            if (ModelState.IsValid)
            {
                _db.Teacher.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Данные изменены успешно!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var teacherFromDb = _db.Teacher.Find(Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }

            return View(teacherFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            var teacherFromDb = _db.Teacher.Find(Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }
            _db.Teacher.Remove(teacherFromDb);
            _db.SaveChanges();
            TempData["error"] = "Учитель удалён!";
            return RedirectToAction("Index");
        }
    }
}
