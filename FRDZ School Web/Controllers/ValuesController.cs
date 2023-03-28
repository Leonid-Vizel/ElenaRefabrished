using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FRDZ_School_Web.Controllers
{
    public class ValuesController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Test()
        {
            return new ViewResult()
            {
                ViewName = "Test",
                ViewData = new ViewDataDictionary(
                           new EmptyModelMetadataProvider(),
                           new ModelStateDictionary())
                           {
                               Model = "Вы находитесь в Test методе!"
                           }
            };
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
