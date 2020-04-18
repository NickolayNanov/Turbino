using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turbino.Application.Common.CommonService;
using Turbino.Application.Destinations.Commands.Create;
using Turbino.Application.Tours.Commands.CreateTour;
using Turbino.WebApp.Controllers;

namespace Turbino.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    public class AdminController : BaseController
    {
        private readonly ICommonService commonService;

        public AdminController(ICommonService commonService)
        {
            this.commonService = commonService;
        }

        [HttpGet]
        [Route("AdminPanel")]
        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        [Route("CreateDestination")]
        public IActionResult CreateDestination()
        {
            return View(new CreateDestinationCommand());
        }

        [HttpPost]
        [Route("CreateDestination")]
        public async Task<IActionResult> CreateDestination(CreateDestinationCommand command)
        {
            await Mediator.Send(command);
            return Redirect("/Destinations");
        }

        [HttpGet]
        [Route("CreateTour")]
        public IActionResult CreateTour()
        {            
            return View(commonService.GetCommand());
        }

        [HttpPost]
        [Route("CreateTour")]
        public async Task<IActionResult> CreateTour(CreateTourCommand command)
        {
            await Mediator.Send(command);
            return Redirect("/Tours");
        }
    }
}
