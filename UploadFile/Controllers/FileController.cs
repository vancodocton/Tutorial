using Microsoft.AspNetCore.Mvc;

namespace UploadFile.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
