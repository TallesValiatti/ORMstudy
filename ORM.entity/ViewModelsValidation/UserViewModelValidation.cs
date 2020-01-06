using FluentValidation;
using ORM.entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.entity.ViewModelsValidation
{
    public class UserViewModelValidation : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidation()
        {
            RuleFor( x => x.name)
                .NotEmpty()
                .MaximumLength(10)
                .NotNull();

            RuleFor(x => x.password)
               .NotEmpty()
               .NotNull();

            RuleFor(x => x.email)
               .NotEmpty()
               .EmailAddress()
               .NotNull();

            RuleFor(x => x.id)
                .Equal(0);
        }
    }
}
