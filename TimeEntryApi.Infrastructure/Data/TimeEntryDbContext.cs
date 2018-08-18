using Microsoft.EntityFrameworkCore;
using TimeEntryApi.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class TimeEntryDbContext : DbContext
{
    public TimeEntryDbContext(DbContextOptions<TimeEntryDbContext> options)
    : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<Employee> Employees { get; set; }
}