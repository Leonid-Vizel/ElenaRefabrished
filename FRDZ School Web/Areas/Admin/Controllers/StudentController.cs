using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.DataAccess.Repository.IRepository;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentUnitOfWork _unitOfWork;
        public StudentController(IStudentUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            var StudentGrade = _unitOfWork.StudentGrade.Include(s => s.Student).Include(g => g.Grade).ToList();
            IEnumerable<Student> objStudentList = await _unitOfWork.Student.GetAllAsync();
            return View(objStudentList);
        }

        public async Task<IActionResult> Add()
        {
            StudentCreateModel model = new StudentCreateModel();
            await _unitOfWork.LoadCreateModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(StudentCreateModel model)
        {
            if (!await _unitOfWork.Grade.AnyAsync(a => a.Id == model.GradeId))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Student student = model.ToStudent();
                await _unitOfWork.Student.AddAsync(student);
                await _unitOfWork.SaveAsync();
                Student_Grade studentGrade = new Student_Grade() { StudentId = student.Id, GradeId = model.GradeId };
                await _unitOfWork.StudentGrade.AddAsync(studentGrade);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Ученик добавлен!";
                return RedirectToAction("Index");
            }
            await _unitOfWork.LoadCreateModel(model);
            return View(model);
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