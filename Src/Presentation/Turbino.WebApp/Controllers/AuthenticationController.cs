using Microsoft.AspNetCore.Mvc;

namespace Turbino.WebApp.Controllers
{
    public class AuthenticationController : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login()
        {
            return this.Redirect("/");
        }
    }
}
