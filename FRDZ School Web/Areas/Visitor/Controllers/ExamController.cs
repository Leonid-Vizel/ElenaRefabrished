using ClosedXML.Excel;
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

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult OgeToExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var Oge = _db.OGEResult.OrderBy(u => u.Id).ToList();

                var worksheet = workbook.Worksheets.Add("OGE_Results");
                int currentCol = 1;

                worksheet.Cell(1, currentCol).Value = "";
                worksheet.Cell(2, currentCol).Value = "Русский язык";
                worksheet.Cell(3, currentCol).Value = "Математика";
                worksheet.Cell(4, currentCol).Value = "Обществознание";
                worksheet.Cell(5, currentCol).Value = "Английский язык";
                worksheet.Cell(6, currentCol).Value = "Информатика";
                worksheet.Cell(7, currentCol).Value = "История";
                worksheet.Cell(8, currentCol).Value = "Биология";
                worksheet.Cell(9, currentCol).Value = "Химия";
                worksheet.Cell(10, currentCol).Value = "География";
                worksheet.Cell(11, currentCol).Value = "Физика";

                foreach (var oge in Oge)
                {
                    currentCol++;
                    worksheet.Cell(1, currentCol).Value = oge.Year;
                    worksheet.Cell(2, currentCol).Value = oge.Russian;
                    worksheet.Cell(3, currentCol).Value = oge.Math;
                    worksheet.Cell(4, currentCol).Value = oge.SocialStudies;
                    worksheet.Cell(5, currentCol).Value = oge.English;
                    worksheet.Cell(6, currentCol).Value = oge.Informatics;
                    worksheet.Cell(7, currentCol).Value = oge.History;
                    worksheet.Cell(8, currentCol).Value = oge.Biology;
                    worksheet.Cell(9, currentCol).Value = oge.Chemistry;
                    worksheet.Cell(10, currentCol).Value = oge.Geography;
                    worksheet.Cell(11, currentCol).Value = oge.Physics;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "OGE_Results.xlsx");
                }
            }
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

        public IActionResult EgeToExcel()
        {
            using (var workbook = new XLWorkbook())
            {
                var Ege = _db.EGEResult.OrderBy(u => u.Id).ToList();

                var worksheet = workbook.Worksheets.Add("EGE_Results");
                int currentCol = 1;

                worksheet.Cell(1, currentCol).Value = "";
                worksheet.Cell(2, currentCol).Value = "Русский язык";
                worksheet.Cell(3, currentCol).Value = "Математика (базовая)";
                worksheet.Cell(4, currentCol).Value = "Математика (профильная)";
                worksheet.Cell(5, currentCol).Value = "Обществознание";
                worksheet.Cell(6, currentCol).Value = "Английский язык";
                worksheet.Cell(7, currentCol).Value = "Информатика";
                worksheet.Cell(8, currentCol).Value = "История";
                worksheet.Cell(9, currentCol).Value = "Биология";
                worksheet.Cell(10, currentCol).Value = "Химия";
                worksheet.Cell(11, currentCol).Value = "География";
                worksheet.Cell(12, currentCol).Value = "Физика";
                worksheet.Cell(13, currentCol).Value = "Литература";

                foreach (var ege in Ege)
                {
                    currentCol++;
                    worksheet.Cell(1, currentCol).Value = ege.Year;
                    worksheet.Cell(2, currentCol).Value = ege.Russian;
                    worksheet.Cell(3, currentCol).Value = ege.MathBase;
                    worksheet.Cell(4, currentCol).Value = ege.MathProfi;
                    worksheet.Cell(5, currentCol).Value = ege.SocialStudies;
                    worksheet.Cell(6, currentCol).Value = ege.English;
                    worksheet.Cell(7, currentCol).Value = ege.Informatics;
                    worksheet.Cell(8, currentCol).Value = ege.History;
                    worksheet.Cell(9, currentCol).Value = ege.Biology;
                    worksheet.Cell(10, currentCol).Value = ege.Chemistry;
                    worksheet.Cell(11, currentCol).Value = ege.Geography;
                    worksheet.Cell(12, currentCol).Value = ege.Physics;
                    worksheet.Cell(13, currentCol).Value = ege.Literature;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EGE_Results.xlsx");
                }
            }
        }
        #endregion
    }
}
