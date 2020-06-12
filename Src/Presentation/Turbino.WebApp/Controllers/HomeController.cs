namespace Turbino.WebApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    using Models;
    using System.Threading.Tasks;
    using Turbino.Domain.Entities;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using Turbino.Application.Home.GetProfile;
    using Turbino.Application.Home.Commands.UpdateUserProfile;
    using Turbino.Application.Tours.Queries.GetAllDestinations;
    using Turbino.Application.Home.Queries.GetIndex;

    public class HomeController : BaseController
    {
        private readonly RoleManager<TurbinoRole> roleManager;
        private readonly UserManager<TurbinoUser> userManager;

        public HomeController(RoleManager<TurbinoRole> roleManager, UserManager<TurbinoUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("/")]
        public async  Task<IActionResult> Index()
        {
            IndexHolderViewModel tours = await Mediator.Send(new GetIndexQuery());
            return View(tours);
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

        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> Profile()
        {
            var userData = await Mediator.Send(new GetProfileQuery() { Username = User.Identity.Name });
            return View(userData);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(string firstName, string lastName, string middleName, string phone)
        {
            GetProfileViewModel userData = await Mediator.Send(new UpdateUserProfileCommand() { UserName = User.Identity.Name, FirstName = firstName, MiddleName = middleName, LastName = lastName, PhoneNumber = phone });
            if(userData.Errors.Length != 0)
            {
                ViewData["Errors"] = userData.Errors;
            }
            return RedirectToAction("Profile", "Home", userData);
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
