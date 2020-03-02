using MediatR;

namespace Turbino.Application.User.Commands.Create
{
    public class CreateTurbinoUserCommand : IRequest
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }


        public string FullName => $"{FirstName} {(string.IsNullOrEmpty(MiddleName) ? "" : MiddleName)} {LastName}";
    }
}
