using Domain.Models;

namespace Domain.IRepositories;

public interface IEmployeeRepository
{
    Task AddEmployeeAcync(Employee employee);
    Task<bool> IsAnyEmployeeAsync(Guid guid);
    Task<Employee> GetEmployeeAsync(Guid guid);
    Task SaveChangesAsync();
}