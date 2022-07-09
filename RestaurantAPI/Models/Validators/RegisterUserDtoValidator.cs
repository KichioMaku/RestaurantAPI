using FluentValidation;
using RestaurantAPI.Entities;
using System.Linq;

namespace RestaurantAPI.Models.Validators
{
    public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator(RestaurantDbContext dbContext)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x=> x.ConfirmPassword)
                .Equal(x=>x.Password);

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emiailInUse = dbContext.Users.Any(x => x.Email == value);
                    if (emiailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });

        }
    }
}
