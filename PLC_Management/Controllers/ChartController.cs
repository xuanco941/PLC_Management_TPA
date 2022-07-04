using Microsoft.AspNetCore.Mvc;

namespace PLC_Management.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
