using Microsoft.AspNetCore.Mvc;

namespace Turbino.WebApp.Controllers
{
    public class TourController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
