namespace Turbino.WebApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Turbino.Domain.Entities;
    using Turbino.Common.GlobalContants;
    using Turbino.Application.Authentication.Login.Commands;
    using Turbino.Application.Authentication.Register.Commands.Create;

    public class AuthenticationController : BaseController
    {
        private readonly SignInManager<TurbinoUser> signInManager;

        public AuthenticationController(SignInManager<TurbinoUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LoginTurbinoUserCommand());
            }
            else
            {
                ViewData["Error"] = WebConstants.AlreadyAuthenticated;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginTurbinoUserCommand command)
        {
            string[] errors = await Mediator.Send(command);

            if (errors.Length != 0)
            {
                ViewData["Errors"] = errors;
                return View(new LoginTurbinoUserCommand());
            }

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new CreateTurbinoUserCommand());
            }
            else
            {
                ViewData["Error"] = WebConstants.AlreadyAuthenticated;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateTurbinoUserCommand command)
        {
            string[] errors = await Mediator.Send(command);

            if (errors.Length > 0)
            {
                ViewData["Errors"] = errors;
                return View(new CreateTurbinoUserCommand());
            }

            return Redirect("/");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
