using Microsoft.AspNetCore.Mvc;
using Chap6.Models;

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
    public ActionResult<List<UserTask>> GetTasks()
    {
        return _tasksService.GetAllTasks();
    }

    [HttpGet("{taskId:Guid}")]
    public ActionResult<UserTask> GetTask([FromRoute] Guid taskId)
    {
        var task = _tasksService.GetTask(taskId);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpPost("")]
    public ActionResult<UserTask> AddNewTask([FromBody] CreateTaskRequestDto newTask)
    {
        var createdTask = _tasksService.AddNewTask(newTask);
        return CreatedAtAction(nameof(GetTask), new { taskId = createdTask.Id }, createdTask);
    }
}