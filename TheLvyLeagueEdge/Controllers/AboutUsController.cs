using Microsoft.AspNetCore.Mvc;

namespace TheLvyLeagueEdge.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
