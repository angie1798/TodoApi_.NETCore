using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data
{
    public class DataContext : DbContext
    {

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Tarea> Tareas { get; set; }

    }
}
