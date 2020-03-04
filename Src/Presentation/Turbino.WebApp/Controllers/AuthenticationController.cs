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
        private readonly RoleManager<TurbinoRole> roleManager;

        public AuthenticationController(RoleManager<TurbinoRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        
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
        public async Task<IActionResult> Register()
        {
            await this.SeedRoles();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateTurbinoUserCommand command)
        {
            await Mediator.Send(command);
            return this.View(command);
        }

        private async Task SeedRoles()
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new TurbinoRole("Admin"));
                await roleManager.CreateAsync(new TurbinoRole("User"));
            }
        }
    }
}
