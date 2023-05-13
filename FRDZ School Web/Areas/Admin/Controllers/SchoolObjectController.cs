using FRDZSchool.DataAccess.Data.UnitOfWork;
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
    public class SchoolObjectController : Controller
    {
        private readonly ISchoolObjectUnitOfWork _unitOfWork;
        public SchoolObjectController(ISchoolObjectUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IActionResult> Index()
        {
            IEnumerable<SchoolObject> objSchoolObjectectList = await _unitOfWork.SchoolObject.GetAllAsync();
            return View(objSchoolObjectectList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(SchoolObjectCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            SchoolObject obj = model.ToSchoolObject();
            await _unitOfWork.SchoolObject.AddAsync(obj);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Предмет добавлен!";
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Edit(int Id)
        {
            var schoolObjectFromDb = await _unitOfWork.SchoolObject.GetAsync(u => u.Id == Id);

            if (schoolObjectFromDb == null)
            {
                return NotFound();
            }

            SchoolObjectEditModel model = new SchoolObjectEditModel(schoolObjectFromDb);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SchoolObjectEditModel model)
        {
            var schoolObjectFromDb = await _unitOfWork.SchoolObject.GetAsync(u => u.Id == model.Id);

            if (schoolObjectFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            schoolObjectFromDb.Update(model);
            _unitOfWork.SchoolObject.Update(schoolObjectFromDb);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Данные изменены успешно!";
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var schoolObjectFromDb = await _unitOfWork.SchoolObject.GetAsync(u => u.Id == Id);

            if (schoolObjectFromDb == null)
            {
                return NotFound();
            }

            _unitOfWork.SchoolObject.Remove(schoolObjectFromDb);
            await _unitOfWork.SaveAsync();
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<SchoolObject> objSchoolObjectList = await _unitOfWork.SchoolObject.GetAllAsync();
            return Json(new { data = objSchoolObjectList });
        }
    }
}
