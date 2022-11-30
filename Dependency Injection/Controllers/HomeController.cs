using Dependency_Injection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log;


        public HomeController(ILog log)
        {
            _log= log;
        }


        public IActionResult Index([FromServices]ILog log)  //Action bazlı dependency Injection(Buradaki değeri Services yani containerdan getir.)
        {
            log.Log();
            return View();
        }
    }
}
