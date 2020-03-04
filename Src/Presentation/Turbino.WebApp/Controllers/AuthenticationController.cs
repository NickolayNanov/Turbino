using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Turbino.Application.Authentication.Login.Commands;
using Turbino.Application.Authentication.Register.Commands.Create;
using Turbino.Domain.Entities;

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
        public async Task<IActionResult> Login(LoginTurbinoUserCommand command)
        {
            await Mediator.Send(command);
            return this.Redirect("/");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateTurbinoUserCommand command)
        {
            await Mediator.Send(command);
            return this.Redirect("/");
        }
    }
}
