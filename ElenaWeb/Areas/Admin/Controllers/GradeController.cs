using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;
using FRDZSchool.Models.ViewModels.EditModels;
using FRDZSchool.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class GradeController : Controller
    {
        private readonly IGradeUnitOfWork _unitOfWork;
        public GradeController(IGradeUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Grade> objGradeList = await _unitOfWork.Grade.GetAllAsync();
            return View(objGradeList);
        }

        public async Task<IActionResult> Add()
        {
            GradeCreateModel model = new GradeCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GradeCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Grade grade = model.ToGrade();
            await _unitOfWork.Grade.AddAsync(grade);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Класс добавлен!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var gradeFromDb = await _unitOfWork.Grade.GetAsync(u => u.Id == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }

            GradeEditModel model = new GradeEditModel(gradeFromDb);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GradeEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var gradeFromDb = await _unitOfWork.Grade.GetAsync(u => u.Id == model.Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }

            gradeFromDb.Update(model);
            _unitOfWork.Grade.Update(gradeFromDb);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Данные изменены успешно!";
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var gradeFromDb = await _unitOfWork.Grade.GetAsync(u => u.Id == Id);

            if (gradeFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.Grade.Remove(gradeFromDb);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Grade> objGradeList = await _unitOfWork.Grade.GetAllAsync();
            return Json(new { data = objGradeList });
        }
    }
}
