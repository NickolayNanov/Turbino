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
            await SeedRoles();
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
            var state = this.ModelState.IsValid;
            GetProfileViewModel userData = await Mediator.Send(new UpdateUserProfileCommand() { UserName = User.Identity.Name, FirstName = firstName, MiddleName = middleName, LastName = lastName, PhoneNumber = phone });
            return RedirectToAction("Profile", "Home", userData);
        }

        private async Task SeedRoles()
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new TurbinoRole("Admin"));
                await roleManager.CreateAsync(new TurbinoRole("User"));
            }

            if (!userManager.Users.Any())
            {
                TurbinoUser user = new TurbinoUser() { UserName = "admin", FirstName = "admin", LastName = "adminov" };
                await userManager.CreateAsync(user, "fr3s7ed23");
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
