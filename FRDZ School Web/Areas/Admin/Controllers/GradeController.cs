using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GradeController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public IActionResult Index()
        {
            IEnumerable<Grade> objGradeList = _unitOfWork.Grade.GetAll().ToList();
            return View(objGradeList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Grade obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Grade.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Класс добавлен!";
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

            var gradeFromDb = _unitOfWork.Grade.Get(u => u.Id == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }

            return View(gradeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Grade obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Grade.Update(obj);
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

            var gradeFromDb = _unitOfWork.Grade.Get(u => u.Id == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }

            return View(gradeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Id)
        {
            var gradeFromDb = _unitOfWork.Grade.Get(u => u.Id == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Grade.Remove(gradeFromDb);
            _unitOfWork.Save();
            TempData["error"] = "Класс удалён!";
            return RedirectToAction("Index");
        }
    }
}
