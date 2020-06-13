namespace Turbino.Application.Home.GetProfile
{
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Turbino.Domain.Entities;

    using MediatR;
    using AutoMapper;

    public class GetProfileHandler : IRequestHandler<GetProfileQuery, GetProfileViewModel>
    {
        private readonly IMapper mapper;
        private readonly UserManager<TurbinoUser> userManager;

        public GetProfileHandler(IMapper mapper, UserManager<TurbinoUser> userManager)
        {
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<GetProfileViewModel> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            TurbinoUser user = await userManager.FindByNameAsync(request.Username);
            return mapper.Map<GetProfileViewModel>(user);
        }
    }
}
