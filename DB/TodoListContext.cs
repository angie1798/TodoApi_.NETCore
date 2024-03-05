
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class TodoListContext: DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options) { }
    }
}