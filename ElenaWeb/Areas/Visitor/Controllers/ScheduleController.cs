using FRDZSchool.DataAccess.Data;
using FRDZSchool.Models.DatabaseModels;
using FRDZSchool.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FRDZ_School_Web.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class ScheduleController : Controller
    {
        private ApplicationContext _db;
        private ScheduleInfo _info;

        public ScheduleController(ApplicationContext db, ScheduleInfo info)
        {
            _db = db;
            _info = info;
        }

        public IActionResult Index()
        {
            return View(_info);
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Reset()
        {
            return View(_info);
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reset(ScheduleInfo updateInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(updateInfo);
            }

            _info.Copy(updateInfo);
            foreach (PropertyInfo propInfo in _info.GetType().GetProperties())
            {
                SettingOption? option = _db.Settings.FirstOrDefault(x => x.Name.Equals(propInfo.Name));
                if (option == null)
                {
                    option = new SettingOption()
                    {
                        Name = propInfo.Name,
                        Value = propInfo.GetValue(_info).ToString()
                    };
                    await _db.Settings.AddAsync(option);
                }
                else
                {
                    option.Value = propInfo.GetValue(_info).ToString();
                    _db.Settings.Update(option);
                }
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}