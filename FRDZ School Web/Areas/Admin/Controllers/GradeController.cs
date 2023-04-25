using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;
using FRDZSchool.Models.ViewModels.EditModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GradeController : Controller
    {
        private readonly IGradeUnitOfWork _unitOfWork;
        public GradeController(IGradeUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            var StudentGrade = _unitOfWork.StudentGrade.Include(g => g.Grade).Include(s => s.Student).ToList();
            IEnumerable<Grade> objGradeList = await _unitOfWork.Grade.GetAllAsync();
            return View(objGradeList);
        }

        public async Task<IActionResult> Add()
        {
            GradeCreateModel model = new GradeCreateModel();
            await _unitOfWork.LoadCreateModel(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GradeCreateModel model)
        {
            if (!await _unitOfWork.Student.AnyAsync(a => a.Id == model.StudentId))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                Grade grade = model.ToGrade();
                await _unitOfWork.Grade.AddAsync(grade);
                await _unitOfWork.SaveAsync();
                Student_Grade studentGrade = new Student_Grade() { StudentId = model.StudentId, GradeId = grade.Id };
                await _unitOfWork.StudentGrade.AddAsync(studentGrade);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Класс добавлен!";
                return RedirectToAction("Index");
            }
            await _unitOfWork.LoadCreateModel(model);
            return View(model);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var gradeFromDb = await _unitOfWork.Grade.GetAsync(u => u.Id == Id);
            var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.GradeId == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }
            if (studentGradeFromDb == null)
            {
                return NotFound();
            }

            GradeEditModel model = new GradeEditModel(gradeFromDb) { StudentId = studentGradeFromDb.StudentId };
            await _unitOfWork.LoadCreateModel(model);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GradeEditModel model)
        {
            if (!await _unitOfWork.Student.AnyAsync(a => a.Id == model.StudentId))
            {
                return NotFound();
            }

            var gradeFromDb = await _unitOfWork.Grade.GetAsync(u => u.Id == model.Id);
            var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.GradeId == model.Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }
            if (studentGradeFromDb == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                gradeFromDb.Update(model);
                if (model.StudentId != studentGradeFromDb.StudentId)
                {
                    studentGradeFromDb.StudentId = model.StudentId;
                    _unitOfWork.StudentGrade.Update(studentGradeFromDb);
                }
                _unitOfWork.Grade.Update(gradeFromDb);
                await _unitOfWork.SaveAsync();
                TempData["success"] = "Данные изменены успешно!";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var gradeFromDb = await _unitOfWork.Grade.GetAsync(u => u.Id == Id);
            var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.GradeId == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }
            if (studentGradeFromDb == null)
            {
                return NotFound();
            }

            return View(gradeFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int Id)
        {
            var gradeFromDb = await _unitOfWork.Grade.GetAsync(u => u.Id == Id);
            //var studentGradeFromDb = await _unitOfWork.StudentGrade.GetAsync(u => u.GradeId == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }
            //if (studentGradeFromDb == null)
            //{
            //    return NotFound();
            //}
            _unitOfWork.Grade.Remove(gradeFromDb);
            //_unitOfWork.StudentGrade.Remove(studentGradeFromDb);
            await _unitOfWork.SaveAsync();
            TempData["error"] = "Класс удалён!";
            return RedirectToAction("Index");
        }
    }
}
