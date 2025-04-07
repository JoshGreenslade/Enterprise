using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Chap6.Controllers;

public class CreateTaskRequestDto
{
    public required string TaskName { get; set; }
    public DateTime DueDate { get; set; }
    public Boolean IsComplete { get; set; }
}

public class CreateTaskRequestDtoValidator : AbstractValidator<CreateTaskRequestDto>
{
    public CreateTaskRequestDtoValidator()
    {
        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Due date must be in the future");

        RuleFor(x => x.TaskName)
            .NotEmpty().WithMessage("Task name cannot be empty.")
            .MinimumLength(5).WithMessage("Task must be at least 5 characters in length.");
    }
}