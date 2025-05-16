using Application.Commands;
using Application.Dto;
using Application.IServices;
using Domain.IRepositories;
using Domain.Models;

namespace Application.Services;

public class EmployeeService:IEmployeeService
{
    private readonly IEmployeeRepository _employee;
    private readonly ILeaveRequestRepository _leaveRequest;

    public EmployeeService(IEmployeeRepository employee, ILeaveRequestRepository leaveRequest)
    {
        _employee = employee;
        _leaveRequest = leaveRequest;
    }

    public async Task AddEmployee(AddEmployeeCommand command)
    {
        var Employee = new Employee(command.FullName,command.Email);
        await _employee.AddEmployeeAcync(Employee);
        await _employee.SaveChangesAsync();
    }

    public async Task<bool> IsAnnyEmployeeAsync(Guid guid)
    {
       return await _employee.IsAnyEmployeeAsync(guid);
    }

    public async Task<EmployeeDTO> GetEmployeeAsync(Guid id)
    {
        var Employee = await _employee.GetEmployeeAsync(id);
        var Request = await _leaveRequest.GetLeaveRequestByUserIdAsync(id);
        var DTO = new EmployeeDTO()
        {
            Email = Employee.Email,
            FullName = Employee.FullName,
            Id = Employee.Id,
        };

        foreach (var item in Request)
        {
            var LeaveRequestDTO = new LeaveRequestDTO()
            {
                Id = item.Id,
                Status = item.Status,
                FromDate = item.FromDate,
                Reason = item.Reason,
                ReplacementEmployeeId = (Guid)item.ReplacementId,
                ToDate = item.ToDate,
            };
            DTO.LeaveRequestDtos.Add(LeaveRequestDTO);
        }

        return DTO;
    }
}