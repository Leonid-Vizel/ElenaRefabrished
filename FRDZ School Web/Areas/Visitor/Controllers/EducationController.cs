using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class EducationController : Controller
    {
        public IActionResult WeekendSchool()
        {
            return View();
        }

        public IActionResult PreSchool()
        {
            return View();
        }

        public IActionResult JuniorSchool()
        {
            return View();
        }

        public IActionResult MiddleSchool()
        {
            return View();
        }

        public IActionResult HighSchool()
        {
            return View();
        }

        public IActionResult Additional()
        {
            return View();
        }
    }
}