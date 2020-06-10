using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
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
            string[] errors = await Mediator.Send(command);
            if (errors.Length != 0)
            {
                ViewData["Errors"] = errors;
                return View(new CreateDestinationCommand());
            }

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
            string[] errors = await Mediator.Send(command);
            if(errors.Length != 0)
            {
                ViewData["Errors"] = errors;
                return View(commonService.GetCommand());
            }
            return Redirect("/Tours");
        }
    }
}
