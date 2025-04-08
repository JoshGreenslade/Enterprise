namespace Chap6.Domain;

public class TaskListDto
{
    public Guid Id { get; set; }
    public required string TaskName { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsComplete { get; set; }

}