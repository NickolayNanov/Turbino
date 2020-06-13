namespace Turbino.WebApp.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;

    using Models;

    using Turbino.Domain.Entities;
    using Turbino.Application.Home.GetProfile;
    using Turbino.Application.Home.Queries.GetIndex;
    using Turbino.Application.Home.Commands.UpdateUserProfile;

    public class HomeController : BaseController
    {
        private const string ProfileRoute = "Profile";
        private const string IndexRoute = "/";

        [HttpGet]
        [Route(IndexRoute)]
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
        [Route(ProfileRoute)]
        public async Task<IActionResult> Profile()
        {
            GetProfileViewModel userData = await Mediator.Send(new GetProfileQuery() { Username = User.Identity.Name });
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

        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
