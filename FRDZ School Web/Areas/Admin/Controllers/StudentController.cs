using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            IEnumerable<Student> objStudentList = _unitOfWork.Student.GetAll().ToList();
            return View(objStudentList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Student obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Ученик добавлен!";
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

            var studentFromDb = _unitOfWork.Student.Get(u => u.Id == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            return View(studentFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Student.Update(obj);
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

            var studentFromDb = _unitOfWork.Student.Get(u => u.Id == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            return View(studentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            var studentFromDb = _unitOfWork.Student.Get(u => u.Id == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Student.Remove(studentFromDb);
            _unitOfWork.Save();
            TempData["error"] = "Ученик удалён!";
            return RedirectToAction("Index");
        }
    }
}