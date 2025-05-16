using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MyContext : DbContext
{
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<LeaveRequest> LeaveRequests { get; set; }
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {

    }


    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    modelBuilder.Entity<Employee>().HasData(
    //        new Employee(Guid.Parse("00000000-0000-0000-0000-000000000001"), "AliMoradi", "ali@gmai.com"),
    //        new Employee(Guid.Parse("00000000-0000-0000-0000-000000000002"), "mohammadAmini", "mohammad@gmai.com"),
    //        new Employee(Guid.Parse("00000000-0000-0000-0000-000000000003"), "HosseinAhmadi", "Hossein@gmai.com"),
    //        new Employee(Guid.Parse("00000000-0000-0000-0000-000000000004"), "MoradGoli", "Morad@gmai.com")


    //        );

    //}
}