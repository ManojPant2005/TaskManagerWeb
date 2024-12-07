using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TM.Api.Data.Entities;
using TM.Shared;

namespace TM.Api.Data
{
    public class TaskContext : DbContext
    {
        private readonly IPasswordHasher<User> _password;

        public TaskContext(DbContextOptions<TaskContext> options, IPasswordHasher<User> password) : base(options)
        {
            _password = password;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminUser = new User
            {
                Id = 1,
                Name = "University Admin",
                Email = "university@email.com",
                Phone = "1234567890",
                Role = nameof(UserRole.Admin),
                IsApproved = true
            };
            adminUser.PasswordHash = _password.HashPassword(adminUser, "123456");

            // Manager User
            var managerUser = new User
            {
                Id = 2,
                Name = "University Manager",
                Email = "manager@email.com",
                Phone = "0987654321",
                Role = nameof(UserRole.Manager),
                IsApproved = true
            };
            managerUser.PasswordHash = _password.HashPassword(managerUser, "123456");

            // Department User
            var departmentUser = new User
            {
                Id = 3,
                Name = "Department Head",
                Email = "department@email.com",
                Phone = "1122334455",
                Role = nameof(UserRole.Department),
                IsApproved = true
            };
            departmentUser.PasswordHash = _password.HashPassword(departmentUser, "123456");

            // Seed Users
            modelBuilder.Entity<User>()
                .HasData(adminUser, managerUser, departmentUser);
        }
    }
}