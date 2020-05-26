﻿using MediatR;
using Turbino.Application.Home.GetProfile;

namespace Turbino.Application.Home.Commands.UpdateUserProfile
{
    public class UpdateUserProfileCommand : IRequest<GetProfileViewModel>
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
