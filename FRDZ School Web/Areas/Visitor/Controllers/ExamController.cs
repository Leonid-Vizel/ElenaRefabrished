using FRDZSchool.DataAccess.Data;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FRDZ_School_Web.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class ExamController : Controller
    {
        private ApplicationContext _db;

        public ExamController(ApplicationContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(new ExamResult()
            {
                Ege = _db.EGEResult.OrderBy(x => x.Year),
                Oge = _db.OGEResult.OrderBy(x => x.Year)
            });
        }

        #region ОГЭ
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult AddOge()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOge(OGEResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            await _db.OGEResult.AddAsync(result);
            await _db.SaveChangesAsync();
            TempData["success"] = "Результаты ОГЭ добавлены!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult EditOge(int Id)
        {
            OGEResult? foundResult = _db.OGEResult.FirstOrDefault(x => x.Id == Id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOge(OGEResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            _db.OGEResult.Update(result);
            await _db.SaveChangesAsync();
            TempData["success"] = "Результаты ОГЭ изменены!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult DeleteOge(int id)
        {
            OGEResult? foundResult = _db.OGEResult.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult.Year);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteOge")]
        public async Task<IActionResult> DeleteOgePost(int id)
        {
            OGEResult? foundResult = _db.OGEResult.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            _db.OGEResult.Remove(foundResult);
            await _db.SaveChangesAsync();
            TempData["success"] = "Результаты ОГЭ удалены!";
            return RedirectToAction("Index");
        }
        #endregion

        #region ЕГЭ
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult AddEge()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEge(EGEResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            await _db.EGEResult.AddAsync(result);
            await _db.SaveChangesAsync();
            TempData["success"] = "Результаты ЕГЭ добавлены!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult EditEge(int Id)
        {
            EGEResult? foundResult = _db.EGEResult.FirstOrDefault(x => x.Id == Id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEge(EGEResult result)
        {
            if (!ModelState.IsValid)
            {
                return View(result);
            }
            _db.EGEResult.Update(result);
            await _db.SaveChangesAsync();
            TempData["success"] = "Результаты ЕГЭ изменены!";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult DeleteEge(int id)
        {
            EGEResult? foundResult = _db.EGEResult.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            return View(foundResult.Year);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        [ActionName("DeleteEge")]
        public async Task<IActionResult> DeleteEgePost(int id)
        {
            EGEResult? foundResult = _db.EGEResult.FirstOrDefault(x => x.Id == id);
            if (foundResult == null)
            {
                return NotFound();
            }
            _db.EGEResult.Remove(foundResult);
            await _db.SaveChangesAsync();
            TempData["success"] = "Результаты ЕГЭ удалены!";
            return RedirectToAction("Index");
        }
        #endregion
    }
}
