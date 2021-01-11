using System.Data.Entity;

namespace DayHelper.DataModel
{
    public class DayHelperContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
