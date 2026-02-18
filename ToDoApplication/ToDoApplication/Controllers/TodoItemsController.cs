using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.Server.Data;
using TodoApp.Server.Models;



namespace TodoApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoDbContext _context;

        public TodoItemsController(TodoDbContext context)
        {
            _context = context;
        }

        // 一覧取得
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems([FromQuery] bool? isCompleted)
        {
            var query = _context.TodoItems.AsQueryable();

            if (isCompleted.HasValue)
                query = query.Where(t => t.IsCompleted == isCompleted.Value);

            return await query
                .OrderBy(t => t.Priority)
                .ThenByDescending(t => t.CreatedAt)
                .ToListAsync();
        }
       
        //1件取得
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
                return NotFound();

            return item;
        }

        // 新規登録
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            item.CreatedAt = DateTime.UtcNow;
            item.UpdatedAt = DateTime.UtcNow;

            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        // 更新
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodoItem(int id, TodoItem item)
        {
            var existing = await _context.TodoItems.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Title = item.Title;
            existing.Description = item.Description;
            existing.IsCompleted = item.IsCompleted;
            existing.Priority = item.Priority;

            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();

        }

        // 削除
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
                return NotFound();

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}



