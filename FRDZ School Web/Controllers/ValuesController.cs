using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FRDZ_School_Web.Controllers
{
    public class ValuesController : Controller
    {
        private readonly IWebHostEnvironment environment;
        public ValuesController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public ViewResult Index()
        {
            return View();
        }

        //public IActionResult File1()
        //{
        //    byte[] content = System.IO.File.ReadAllBytes("C:/Users/Франгиза/OneDrive/Рабочий стол/4cab1648a8c8499f.pdf");
        //    return File(content, "application/pdf", "NewFile.docx");
        //}

        //public IActionResult File2()
        //{
        //    FileStream fs = System.IO.File.OpenRead("C:/Users/Франгиза/OneDrive/Рабочий стол/4cab1648a8c8499f.pdf");
        //    return File(fs, "application/pdf");
        //}

        //public IActionResult File3()
        //{
        //    return PhysicalFile(environment.ContentRootPath + @"C:/Users/Франгиза/OneDrive/Рабочий стол/4cab1648a8c8499f.pdf", "application/pdf");
        //}

        public ViewResult Test()
        {
            return new ViewResult()
            {
                ViewName = "Test",
                ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
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
