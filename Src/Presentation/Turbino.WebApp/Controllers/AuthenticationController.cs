using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Turbino.Application.Authentication.Login.Commands;
using Turbino.Application.Authentication.Register.Commands.Create;
using Turbino.Common.GlobalContants;
using Turbino.Domain.Entities;

namespace Turbino.WebApp.Controllers
{
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
            string error = await Mediator.Send(command);
            if (!string.IsNullOrEmpty(error))
            {
                ViewData["Errors"] = error;
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
            string error = await Mediator.Send(command);
            if (!string.IsNullOrEmpty(error))
            {
                ViewData["Errors"] = error;
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
