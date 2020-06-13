namespace Turbino.Application.Home.GetProfile
{
    using MediatR;

    public class GetProfileQuery : IRequest<GetProfileViewModel>
    {
        public string Username { get; set; }
    }
}