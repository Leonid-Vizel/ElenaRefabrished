using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FRDZ_School_Web.Controllers
{
    public class ValuesController : Controller
    {
        public ViewResult Index()
        {
            string userName = User.Identity.Name;
            var headers = Request.Headers.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.First());
            if (userName == null)
                userName = "";

            foreach (var k in headers.Keys)
                userName += "\n" + k + " - " + headers[k];

            return userName;
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
