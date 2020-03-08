using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turbino.Application.Destinations.Create;
using Turbino.WebApp.Controllers;

namespace Turbino.WebApp.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : BaseController
    {
        [HttpGet]
        [Route("AdminPanel")]
        public IActionResult AdminPanel()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult CreateDestination()
        {
            return this.View();
        }

        [HttpPost]        
        public async Task<IActionResult> CreateDestination(CreateDestinationCommand command)
        {
            await Mediator.Send(command);
            return this.Redirect("/Destinations");
        }
    }
}
