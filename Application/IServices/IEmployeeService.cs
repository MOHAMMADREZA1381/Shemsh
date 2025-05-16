using Application.Commands;
using Application.Dto;

namespace Application.IServices;

public interface IEmployeeService
{
    Task AddEmployee(AddEmployeeCommand command);
    Task<bool> IsAnnyEmployeeAsync(Guid guid);
    Task<EmployeeDTO> GetEmployeeAsync(Guid id);
}