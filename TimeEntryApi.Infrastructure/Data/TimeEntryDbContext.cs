using Microsoft.EntityFrameworkCore;
using TimeEntryApi.Core;

public class TimeEntryDbContext : DbContext
{
    public TimeEntryDbContext(DbContextOptions<TimeEntryDbContext> options)
    : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Department> Departments {get;set;}
    public DbSet<Project> Projects { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
}