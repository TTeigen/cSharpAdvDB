using Microsoft.AspNetCore.Mvc;
using SweetsTreats.Models;

namespace SweetsTreats.Controllers
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