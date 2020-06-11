using MediatR;

namespace Turbino.Application.Authentication.Login.Commands
{
    public class LoginTurbinoUserCommand : IRequest<string[]>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
