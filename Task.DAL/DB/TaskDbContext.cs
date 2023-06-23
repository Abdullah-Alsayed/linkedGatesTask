using Microsoft.EntityFrameworkCore;

namespace Task.DAL.DB
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<CategorieProperties> PropertysCategories { get; set; }
        public virtual DbSet<DeviceProperties>  DeviceProperties { get; set; }
    }
}