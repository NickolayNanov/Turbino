using MediatR;

namespace Turbino.Application.Home.GetProfile
{
    public class GetProfileQuery : IRequest<GetProfileViewModel>
    {
        public string Username { get; set; }
    }
}