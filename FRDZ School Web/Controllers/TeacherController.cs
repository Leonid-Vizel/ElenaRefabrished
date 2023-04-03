using FRDZSchool.DataAccess.Data;
using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepo;
        public TeacherController(ITeacherRepository db) => _teacherRepo = db;

        public IActionResult Index()
        {
            IEnumerable<Teacher> objTeacherList = _teacherRepo.GetAll().ToList();
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
                _teacherRepo.Add(obj);
                _teacherRepo.Save();
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

            var teacherFromDb = _teacherRepo.Get(u => u.Id == Id);

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
                _teacherRepo.Update(obj);
                _teacherRepo.Save();
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

            var teacherFromDb = _teacherRepo.Get(u => u.Id == Id);

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
            var teacherFromDb = _teacherRepo.Get(u => u.Id == Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }
            _teacherRepo.Remove(teacherFromDb);
            _teacherRepo.Save();
            TempData["error"] = "Учитель удалён!";
            return RedirectToAction("Index");
        }
    }
}
