namespace Chap6.Models;

public class UserTask
{
    private const int MIN_TASK_NAME_LENGTH = 5;
    
    public string TaskName { get; private set; } = null!;
    public DateTime DueDate { get; private set; }
    public Boolean IsComplete { get; private set;  }

    public UserTask(string taskName, DateTime dueDate, bool isComplete)
    {
        RenameTask(taskName);
        RescheduleTask(dueDate);
        IsComplete = isComplete;
    }

    public void RenameTask(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Task name cannot be empty");
        if (name.Trim().Length < MIN_TASK_NAME_LENGTH)
        {
            throw new ArgumentException($"Task name must be at least {MIN_TASK_NAME_LENGTH} characters long");
        }

        TaskName = name;
    }

    public void RescheduleTask(DateTime dueDate)
    {
        if (dueDate <= DateTime.UtcNow)
            throw new ArgumentException("Date time must be in the future");

        DueDate = dueDate;
    }

    public void MarkCompleted() => IsComplete = true;
    public void MarkIncomplete() => IsComplete = false;
}