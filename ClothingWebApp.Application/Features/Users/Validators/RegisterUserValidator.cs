using ClothingWebApp.Application.Features.Users.Commands.RegisterUser;
using FluentValidation;


namespace ClothingWebApp.Application.Features.Users.Validators
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(50).WithMessage("First name must be less than 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(50).WithMessage("Last name must be less than 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one number.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State is required.");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("Zip code is required.")
                .Matches(@"^\d{4,9}$").WithMessage("Zip code must be between 4 and 9 digits.");

        }
    }
}
