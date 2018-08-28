using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeEntryApi.Core;

public class TimeEntryDbContext : DbContext
{
    public TimeEntryDbContext(DbContextOptions<TimeEntryDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(new Department{ DepartmentId=1, Name="Executive", CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsVisible = true, IsDeleted=false  });

        var emp1 = new Employee() { Id = "1", DepartmentId=1, FirstName = "Tom", LastName = "Vaidyan", Email = "tom@test.com", UserName = "tom@test.com", EmailConfirmed = true, NormalizedEmail = "TOM@TEST.COM", NormalizedUserName = "TOM@TEST.COM", CreatedBy = "System", CreatedDate = DateTime.Now, UpdatedBy = "System", UpdatedDate = DateTime.Now, IsVisible = true, IsDeleted=false };

        SetPasswordHash(emp1);

        modelBuilder.Entity<Employee>().HasData(
            emp1
        );

    }

    private void SetPasswordHash(Employee applicationUser)
    {
        var passwordHasher = new PasswordHasher<Employee>();

        // Hash the Password Secret:
        string passwordHash = passwordHasher.HashPassword(applicationUser, "Test123!");

        // And set it for the Password Hash:
        applicationUser.PasswordHash = passwordHash;
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Employee> Employees { get; set; }
}