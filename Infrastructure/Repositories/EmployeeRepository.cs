using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmployeeRepository:IEmployeeRepository
{
    private readonly MyContext _context;

    public EmployeeRepository(MyContext context)
    {
        _context = context;
    }


    public async Task AddEmployeeAcync(Employee employee)
    {
        await _context.AddAsync(employee);
    }

  

    public async Task<bool> IsAnyEmployeeAsync(Guid guid)
    {
        return await _context.Employees.AnyAsync(a => a.Id == guid);
    }

    public async Task<Employee> GetEmployeeAsync(Guid guid)
    {
        return await _context.Employees.Where(a => a.Id == guid).FirstOrDefaultAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}