using Microsoft.AspNetCore.Mvc;

namespace Nursing_Student_Vetting.Controllers
{
    public class StudentTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
