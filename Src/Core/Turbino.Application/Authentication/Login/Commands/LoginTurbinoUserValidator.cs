﻿using FluentValidation;

namespace Turbino.Application.Authentication.Login.Commands
{
    public class LoginTurbinoUserValidator : AbstractValidator<LoginTurbinoUserCommand>
    {
        public LoginTurbinoUserValidator()
        {
            RuleFor(l => l.Username)
                .NotEmpty()
                .NotNull();

            RuleFor(l => l.Password)
                .NotEmpty()
                .NotNull();
        }
    }
}