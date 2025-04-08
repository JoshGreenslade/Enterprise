using Chap6.Controllers;
using Chap6.Models;
using Chap6.Common;
using Chap6.Domain;

public class TasksService
{
    private readonly ITasksRepository _tasksRepository;
    private ILogger<TasksService> _logger;

    public TasksService(ITasksRepository tasksRepository, ILogger<TasksService> logger)
    {
        _tasksRepository = tasksRepository;
        _logger = logger;
    }

    public Result<List<TaskListDto>> GetAllTasks()
    {
        var tasks = _tasksRepository.GetAllTasks();
        if (tasks == null)
        {
            _logger.LogError("No tasks found when getting all tasks");
            return Result<List<TaskListDto>>.Failed("No tasks found when getting all tasks");
        }
        var taskList = tasks.Select(task =>
            new TaskListDto
            {
                Id = task.Id,
                TaskName = task.TaskName,
                DueDate = task.DueDate,
                IsComplete = task.IsComplete
            });
        return Result<List<TaskListDto>>.Ok(taskList);
    }

    public TaskDetailDto GetTaskById(Guid taskId)
    {
        var task = _tasksRepository.GetTaskById(taskId);
        var taskDetail = new TaskDetailDto
        {
            Id = task.Id,
            TaskName = task.TaskName,
            DueDate = task.DueDate,
            IsComplete = task.IsComplete
        };
        return taskDetail;
    }

    public Result<UserTask> AddNewTask(CreateNewTaskCommandDto newTask)
    {
        try
        {
            var task = new UserTask(
                taskName: newTask.TaskName,
                dueDate: newTask.DueDate,
                isComplete: newTask.IsComplete);
            _tasksRepository.AddNewTask(task);
            return Result<UserTask>.Ok(task);
        }
        catch (ArgumentException ex)
        {
            return Result<UserTask>.Failed($"Validation of model failed - {ex.Message}");
        }
    }
}