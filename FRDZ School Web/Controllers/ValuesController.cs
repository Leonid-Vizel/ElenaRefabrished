using Microsoft.AspNetCore.Mvc;

namespace FRDZ_School_Web.Controllers
{
    public class ValuesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            string[] data = { "first", "second", "third" };
            return View(data);
        }

        public IActionResult Calc(int x, int y)
        {
            int z = (x * y) + (x / y) - y;
            return View(z);
        }

        public IActionResult Mult(string catchall)
        {
            int mult = 1;
            string[] ss = catchall.Split('/');
            foreach (string s in ss)
            {
                if (int.TryParse(s, out int k))
                    mult *= k;
            }
            return View(mult);
        }
    }
}
