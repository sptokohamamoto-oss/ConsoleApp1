using Refit;
using TodoApp.Client.Models;

namespace TodoApp.Client.Services
{
    //ToDo API 呼び出し用のインターフェース
    //Refitにより型安全なREST通信を実現
    public interface ITodoApi
    {
        [Get("/api/TodoItems")]
        Task<List<TodoItem>> GetAllAsync([Query] bool? isCompleted = null);

        [Get("/api/TodoItems/{id}")]
        Task<TodoItem> GetByIdAsync(int id);

        [Post("/api/TodoItems")]
        Task<TodoItem> CreateAsync([Body] TodoItem item);

        [Put("/api/TodoItems/{id}")]
        Task UpdateAsync(int id, [Body] TodoItem item);

        [Delete("/api/TodoItems/{id}")]
        Task DeleteAsync(int id);
    }
}


