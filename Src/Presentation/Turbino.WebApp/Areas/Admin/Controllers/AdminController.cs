using Microsoft.AspNetCore.Mvc;
using Turbino.WebApp.Controllers;

namespace Turbino.WebApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminController : BaseController
    {
        [HttpGet]
        [Route("AdminPanel")]
        public IActionResult AdminPanel()
        {
            return this.View();
        }

        [HttpGet]
        [Route("Admin/Create")]
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
