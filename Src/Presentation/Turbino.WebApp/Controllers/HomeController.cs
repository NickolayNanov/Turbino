namespace Turbino.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using Models;
    using Turbino.Application.Managers.Queries.GetAllManagers;
    using System.Threading.Tasks;

    public class HomeController : BaseController
    {
        [HttpGet]
        [Route("/")]
        //[Route("Home/Index")]
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
