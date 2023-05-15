using FRDZSchool.DataAccess.Data;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class DocumentController : Controller
    {
        private ApplicationContext _db;
        private IWebHostEnvironment _environment;

        public DocumentController(ApplicationContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View(_db.Document);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(int id = 0)
        {
            Document? foundModel = _db.Document.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return NotFound();
            }
            return File($"documents\\{foundModel.DocumentName}", "application/pdf");
        }

        public async Task<IActionResult> Document(string name)
        {
            Document? foundModel = _db.Document.FirstOrDefault(x => x.Title.Equals(name));
            if (foundModel == null)
            {
                return NotFound();
            }
            return File($"documents\\{foundModel.DocumentName}", "application/pdf");
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Add()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public async Task<IActionResult> Add(Document model)
        {
            if (_db.Document.Select(x => x.Title).Any(x => x.Equals(model.Title)))
            {
                ModelState.AddModelError("Title", "Это название уже использовано");
            }
            if (!model.DocumentFile.ContentType.Equals("application/pdf"))
            {
                ModelState.AddModelError("DocumentFile", "Неверный формат документа. Загрузите документ в формате pdf");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string wwwRootImagePath = $"{_environment.WebRootPath}\\documents\\";
            string fileExtention = Path.GetExtension(model.DocumentFile.FileName);
            model.DocumentName = $"{model.Title}{fileExtention}";
            try
            {
                using (var imageCreateStream = new FileStream(Path.Combine(wwwRootImagePath, model.DocumentName), FileMode.Create))
                {
                    await model.DocumentFile.CopyToAsync(imageCreateStream);
                }
            }
            catch
            {
                ModelState.AddModelError("Title", "Некорректное название");
                return View(model);
            }
            await _db.Document.AddAsync(model);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Edit(int id = 0)
        {
            Document? foundModel = _db.Document.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return NotFound();
            }
            return View(foundModel);
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        public async Task<IActionResult> Edit(Document model)
        {
            if (ModelState.IsValid || ModelState["Title"]?.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid)
            {
                if (_db.Photo.Select(x => x.Title).Any(x => x.Equals(model.Title)))
                {
                    ModelState.AddModelError("Title", "Это название уже использовано");
                    return View(model);
                }
                Document? foundModel = _db.Document.FirstOrDefault(x => x.Id == model.Id);
                if (foundModel != null)
                {
                    string wwwRootImagePath = $"{_environment.WebRootPath}\\documents\\";
                    string oldPath = Path.Combine(wwwRootImagePath, foundModel.DocumentName);
                    string newFileName = $"{model.Title}{Path.GetExtension(foundModel.DocumentName)}";
                    string newPath = Path.Combine(wwwRootImagePath, newFileName);
                    try
                    {
                        System.IO.File.Copy(oldPath, newPath);
                        System.IO.File.Delete(oldPath);
                    }
                    catch
                    {
                        ModelState.AddModelError("Title", "Некорректное название");
                        return View(model);
                    }

                    foundModel.Title = model.Title;
                    foundModel.DocumentName = newFileName;
                    _db.Document.Update(foundModel);
                    await _db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int id = 0)
        {
            Document? foundModel = _db.Document.FirstOrDefault(x => x.Id == id);
            if (foundModel == null)
            {
                return NotFound();
            }
            return View(id);
        }

        [ValidateAntiForgeryToken]
        [Authorize(Roles = SD.Role_Admin)]
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int id = 0)
        {
            Document? foundModel = _db.Document.FirstOrDefault(x => x.Id == id);
            if (foundModel != null)
            {
                string wwwRootImagePath = $"{_environment.WebRootPath}\\documents\\";
                string oldPath = Path.Combine(wwwRootImagePath, foundModel.DocumentName);
                try
                {
                    System.IO.File.Delete(oldPath);
                }
                catch { }
                _db.Document.Remove(foundModel);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
