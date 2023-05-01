using FRDZSchool.DataAccess.Data.UnitOfWork.IUnitOfWork;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Models.ViewModels.CreateModels;
using FRDZSchool.Models.ViewModels.EditModels;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly ITeacherUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;
        public TeacherController(ITeacherUnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Teacher> objTeacherList = await _unitOfWork.Teacher.GetAllAsync();
            return View(objTeacherList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(TeacherCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Teacher teacher = model.ToTeacher();
            string wwwRootPath = _environment.WebRootPath;
            if (model.Photo != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                string teacherPath = Path.Combine(wwwRootPath, Path.Combine("images", "teachers"));
                using (var fileStream = new FileStream(Path.Combine(teacherPath, fileName), FileMode.Create))
                {
                    await model.Photo.CopyToAsync(fileStream);
                };
                teacher.PhotoUrl = fileName;
            }
            await _unitOfWork.Teacher.AddAsync(teacher);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Учитель добавлен!";
            return RedirectToAction("Index");

        }


        public async Task<IActionResult> Edit(int Id)
        {
            var teacherFromDb = await _unitOfWork.Teacher.GetAsync(u => u.Id == Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }

            TeacherEditModel model = new TeacherEditModel(teacherFromDb);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeacherEditModel model)
        {
            var teacherFromDb = await _unitOfWork.Teacher.GetAsync(u => u.Id == model.Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            teacherFromDb.Update(model);
            string wwwRootPath = _environment.WebRootPath;
            if (model.Photo != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Photo.FileName);
                string teacherPath = Path.Combine(wwwRootPath, Path.Combine("images", "teachers"));
                using (var fileStream = new FileStream(Path.Combine(teacherPath, fileName), FileMode.Create))
                {
                    await model.Photo.CopyToAsync(fileStream);
                }
                teacherFromDb.PhotoUrl = fileName;
            }
            _unitOfWork.Teacher.Update(teacherFromDb);
            await _unitOfWork.SaveAsync();
            TempData["success"] = "Данные изменены успешно!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var teacherFromDb = await _unitOfWork.Teacher.GetAsync(u => u.Id == Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }

            return View(teacherFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int Id)
        {
            var teacherFromDb = await _unitOfWork.Teacher.GetAsync(u => u.Id == Id);

            if (teacherFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Teacher.Remove(teacherFromDb);
            await _unitOfWork.SaveAsync();
            TempData["error"] = "Учитель удалён!";
            return RedirectToAction("Index");
        }
    }
}
