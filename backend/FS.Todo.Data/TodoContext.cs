using Microsoft.EntityFrameworkCore;
using System.Data;
using System;
using System.Reflection.Metadata;
using FS.Todo.Data.Entities;

namespace FS.Todo.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
           
        public DbSet<Admins> Admins { get; set; }
        public DbSet<LinkRolesMenus> LinkRolesMenus { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Entities.Todo> Todo { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Directory> Directory { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID=postgres;Password=kazakh;Host=localhost;Port=5432;Database=databd;Pooling=true;");
            }

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Todo>()
            .Property(b => b.Id)
            .IsRequired();
            modelBuilder.Entity<Status>()
            .Property(b => b.Id)
            .IsRequired();
            modelBuilder.Entity<Directory>()
           .Property(b => b.Id)
           .IsRequired();
            modelBuilder.Entity<Admins>(entity =>
            {
                entity.ToTable("admins");

                entity.HasIndex(e => e.RolesId)
                    .HasName("admins_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.RolesId)
                    .HasColumnName("roles_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.RolesId)
                    .HasConstraintName("admins_ibfk_1");
            });

            modelBuilder.Entity<LinkRolesMenus>(entity =>
            {
                entity.ToTable("link_roles_menus");

                entity.HasIndex(e => e.MenusId)
                    .HasName("menus_id");

                entity.HasIndex(e => e.RolesId)
                    .HasName("roles_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MenusId)
                    .HasColumnName("menus_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RolesId)
                    .HasColumnName("roles_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Menus)
                    .WithMany(p => p.LinkRolesMenus)
                    .HasForeignKey(d => d.MenusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("link_roles_menus_ibfk_1");

                entity.HasOne(d => d.Roles)
                    .WithMany(p => p.LinkRolesMenus)
                    .HasForeignKey(d => d.RolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("link_roles_menus_ibfk_2");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.ToTable("menus");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });
        
        }

    }
}