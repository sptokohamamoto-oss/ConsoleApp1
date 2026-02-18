using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Server.Models
{
    public class TodoItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;　　

        public string? Description { get; set; }　　　　

        public bool IsCompleted { get; set; } = false;　　

        public DateTime? DueDate { get; set; }　　　

        public int Priority { get; set; } = 2;　　

        public DateTime CreatedAt { get; set; }　　

        public DateTime UpdatedAt { get; set; }　　
    }
}
