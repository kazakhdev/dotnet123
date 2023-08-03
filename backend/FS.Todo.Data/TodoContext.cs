using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FS.Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Entities.Todo> Todo { get; set; }
        public DbSet<Entities.Status> Status { get; set; }
        public DbSet<Entities.Directory> Directory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=kazakh;Host=localhost;Port=5432;Database=databd;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Todo>()
            .Property(b => b.Id)
            .IsRequired();
            modelBuilder.Entity<Entities.Status>()
            .Property(b => b.Id)
            .IsRequired();
            modelBuilder.Entity<Entities.Directory>()
           .Property(b => b.Id)
           .IsRequired();
        }

    }
}