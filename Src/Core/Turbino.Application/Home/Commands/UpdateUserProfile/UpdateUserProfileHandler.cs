using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Turbino.Application.Home.GetProfile;
using Turbino.Domain.Entities;

namespace Turbino.Application.Home.Commands.UpdateUserProfile
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, GetProfileViewModel>
    {
        private readonly UserManager<TurbinoUser> userManager;
        private readonly IMapper mapper;

        public UpdateUserProfileHandler(UserManager<TurbinoUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<GetProfileViewModel> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            TurbinoUser user = await userManager.FindByNameAsync(request.UserName);

            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            await userManager.UpdateAsync(user);
            return mapper.Map<GetProfileViewModel>(user);
        }
    }
}
