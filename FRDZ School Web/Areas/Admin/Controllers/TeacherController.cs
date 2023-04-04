using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeacherController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            IEnumerable<Teacher> objTeacherList = _unitOfWork.Teacher.GetAll().ToList();
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
                _unitOfWork.Teacher.Add(obj);
                _unitOfWork.Save();
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

            var teacherFromDb = _unitOfWork.Teacher.Get(u => u.Id == Id);

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
                _unitOfWork.Teacher.Update(obj);
                _unitOfWork.Save();
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

            var teacherFromDb = _unitOfWork.Teacher.Get(u => u.Id == Id);

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
            var teacherFromDb = _unitOfWork.Teacher.Get(u => u.Id == Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Teacher.Remove(teacherFromDb);
            _unitOfWork.Save();
            TempData["error"] = "Учитель удалён!";
            return RedirectToAction("Index");
        }
    }
}
