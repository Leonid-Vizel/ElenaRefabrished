using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;
using FRDZSchool.Models.ViewModels.EditModels;
using FRDZSchool.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class StudentController : Controller
    {
        private readonly IStudentUnitOfWork _unitOfWork;
        public StudentController(IStudentUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> objStudentList = await _unitOfWork.Student.Include(u => u.Grade).ToListAsync();
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
            if (!ModelState.IsValid)
            {
                await _unitOfWork.LoadCreateModel(model);
                return View(model);
            }
            Student student = model.ToStudent();
            await _unitOfWork.Student.AddAsync(student);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Ученик добавлен!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var studentFromDb = await _unitOfWork.Student.GetAsync(u => u.Id == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            StudentEditModel model = new StudentEditModel(studentFromDb);
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

            if (studentFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            studentFromDb.Update(model);
            _unitOfWork.Student.Update(studentFromDb);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Данные изменены успешно!";
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var studentFromDb = await _unitOfWork.Student.GetAsync(u => u.Id == Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Student.Remove(studentFromDb);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Student> objStudentList = await _unitOfWork.Student.Include(u => u.Grade).ToListAsync();
            return Json(new { data = objStudentList });
        }
    }
}