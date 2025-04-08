using FluentValidation;

namespace Chap6.Controllers;

public class CreateNewTaskCommandDto
{
    public required string TaskName { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; }
}