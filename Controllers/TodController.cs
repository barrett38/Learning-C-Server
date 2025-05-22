using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private static List<TodoItem> todos = new();

    [HttpGet]
    public IActionResult GetAll() => Ok(todos);

    [HttpPost]
    public IActionResult Create(TodoItem item)
    {
        item.Id = todos.Count + 1;
        todos.Add(item);
        return CreatedAtAction(nameof(GetAll), new { id = item.Id }, item);
    }
}
