
using Microsoft.AspNetCore.Mvc;


namespace EpicodusGossip.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
