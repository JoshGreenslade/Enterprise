using FluentValidation;

namespace Chap6.Controllers;

public class VeryPoorLoginRequestDto
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class VeryPoorLoginRequestDtoValidator : AbstractValidator<VeryPoorLoginRequestDto>
{
    public VeryPoorLoginRequestDtoValidator()
    {
        RuleFor(v => v.Username)
        .NotEmpty().WithMessage("Username Missing")
        .EmailAddress().WithMessage("Invalid Email Format");

        RuleFor(v => v.Password)
        .NotEmpty().WithMessage("Password missing")
        .Matches("MySecretPassword").WithMessage("You've not typed MySecretPassword as the password");
    }
}