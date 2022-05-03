﻿using Blog.Domain.Commands.User;

namespace Blog.Domain.Validations.User;

public class RegisterNewUserCommandValidation : UserValidation<RegisterNewUserCommand, Guid>
{
    public RegisterNewUserCommandValidation()
    {
        ValidateFirstName();
        ValidateLastName();
        ValidateEmail();
        ValidatePassword();
    }
}