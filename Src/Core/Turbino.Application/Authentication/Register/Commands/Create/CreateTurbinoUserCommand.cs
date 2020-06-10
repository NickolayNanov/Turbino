using MediatR;

namespace Turbino.Application.Authentication.Register.Commands.Create
{
    public class CreateTurbinoUserCommand : IRequest<string>
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FullName => $"{FirstName} {(string.IsNullOrEmpty(MiddleName) ? "" : MiddleName)} {LastName}";
    }
}
