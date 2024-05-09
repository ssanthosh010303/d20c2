/*
 * Author: Sakthi Santhosh
 * Created on: 09/05/2024
 */
using EmployeeLibrary.Models;

using Microsoft.EntityFrameworkCore;

namespace EmployeeLibrary.Repository;

public class YourDbContext : DbContext
{
    public YourDbContext(DbContextOptions<YourDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employees");
    }
}
