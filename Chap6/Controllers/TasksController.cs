using Microsoft.AspNetCore.Mvc;
using Chap6.Models;
using Chap6.Domain;

namespace Chap6.Controllers;

[ApiController]
public class TasksController : Controller
{

    private readonly TasksService _tasksService;

    public TasksController(TasksService tasksService)
    {
        _tasksService = tasksService;
    }

    [HttpGet("")]
    public ActionResult<List<TaskListDto>> GetTasks()
    {
        var result = _tasksService.GetAllTasks();
        if (!result.IsSuccess)
            return BadRequest();
        var data = result.Data!;
        return data;
    }

    [HttpGet("{taskId:Guid}")]
    public ActionResult<TaskDetailDto> GetTask([FromRoute] Guid taskId)
    {
        var task = _tasksService.GetTaskById(taskId);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpPost("")]
    public ActionResult<UserTask> AddNewTask([FromBody] CreateTaskRequestDto newTask)
    {
        var createNewTask = new CreateNewTaskCommandDto
        {
            TaskName = newTask.TaskName,
            DueDate = newTask.DueDate,
            IsComplete = newTask.IsComplete
        };
        var result = _tasksService.AddNewTask(createNewTask);
        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);
        var createdTask = result.Data!;
        return CreatedAtAction(nameof(GetTask), new { taskId = createdTask.Id }, createdTask);
    }
}