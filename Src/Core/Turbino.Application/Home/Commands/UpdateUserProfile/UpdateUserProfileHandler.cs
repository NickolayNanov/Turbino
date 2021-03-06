﻿namespace Turbino.Application.Home.Commands.UpdateUserProfile
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Turbino.Domain.Entities;
    using Turbino.Application.Home.GetProfile;

    using MediatR;
    using AutoMapper;
    using FluentValidation;
    using FluentValidation.Results;

    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, GetProfileViewModel>
    {
        private readonly UserManager<TurbinoUser> userManager;
        private readonly IMapper mapper;
        private readonly IValidator<UpdateUserProfileCommand> validator;

        public UpdateUserProfileHandler(UserManager<TurbinoUser> userManager, IMapper mapper, IValidator<UpdateUserProfileCommand> validator)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.validator = validator;
        }

        public async Task<GetProfileViewModel> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            ValidationResult validation = await validator.ValidateAsync(request);           
            TurbinoUser user = await userManager.FindByNameAsync(request.UserName);

            user.FirstName = request.FirstName;
            user.MiddleName = request.MiddleName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;

            if (!validation.IsValid)
            {
                GetProfileViewModel model = mapper.Map<GetProfileViewModel>(user);
                model.Errors = validation.Errors.Select(x => x.ErrorMessage).ToArray();

                return model;
            }
            else
            {
                await userManager.UpdateAsync(user);
            }

            return mapper.Map<GetProfileViewModel>(user);
        }
    }
}
