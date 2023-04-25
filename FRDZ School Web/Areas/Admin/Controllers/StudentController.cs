using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;
using FRDZSchool.Models.ViewModels.EditModels;
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

        public async Task<IActionResult> Edit(int Id)
        {
            var studentFromDb = await _unitOfWork.Student.GetAsync(u => u.Id == Id);
            var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.StudentId == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            if (studentGradeFromDb == null)
            {
                return NotFound();
            }

            StudentEditModel model = new StudentEditModel(studentFromDb) { GradeId = studentGradeFromDb.GradeId };
            await _unitOfWork.LoadCreateModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentEditModel model)
        {
            if (!await _unitOfWork.Grade.AnyAsync(a => a.Id == model.GradeId))
            {
                return NotFound();
            }

            var studentFromDb = await _unitOfWork.Student.GetAsync(u => u.Id == model.Id);
            var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.StudentId == model.Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            if (studentGradeFromDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                studentFromDb.Update(model);
                if (model.GradeId != studentGradeFromDb.GradeId)
                {
                    studentGradeFromDb.GradeId = model.GradeId;
                    _unitOfWork.StudentGrade.Update(studentGradeFromDb);
                }
                _unitOfWork.Student.Update(studentFromDb);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Данные изменены успешно!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var studentFromDb = await _unitOfWork.Student.GetAsync(u => u.Id == Id);
            var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.StudentId == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            if (studentGradeFromDb == null)
            {
                return NotFound();
            }

            return View(studentFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int Id)
        {
            var studentFromDb = await _unitOfWork.Student.GetAsync(u => u.Id == Id);
            //var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.StudentId == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }
            //if (studentGradeFromDb == null)
            //{
            //    return NotFound();
            //}
            _unitOfWork.Student.Remove(studentFromDb);
            //_unitOfWork.StudentGrade.Remove(studentGradeFromDb);
            await _unitOfWork.SaveAsync();
            TempData["error"] = "Ученик удалён!";
            return RedirectToAction("Index");
        }
    }
}