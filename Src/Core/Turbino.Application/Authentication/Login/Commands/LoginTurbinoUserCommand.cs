namespace Turbino.Application.Authentication.Login.Commands
{
    using MediatR;

    public class LoginTurbinoUserCommand : IRequest<string[]>
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
