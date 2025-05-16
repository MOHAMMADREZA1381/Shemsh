using Application.Commands;
using Application.Dto;
using Application.IServices;
using Domain.IRepositories;
using Domain.Models;

namespace Application.Services;

public class LeaveRequestService : ILeaveRequestService
{
    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IEmployeeRepository _employeeRepository;
    public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository, IEmployeeRepository employeeRepository)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _employeeRepository = employeeRepository;
    }




    public async Task<bool> AddNewRequestAsync(NewRequestCommand command)
    {
        var IsReplacementBussy =
            await _leaveRequestRepository.IsAnyLeaveRequestAsync(command.ReplacementEmployeeId, command.FromDate,
                command.ToDate);

        if (IsReplacementBussy == false)
        {
            var request = new LeaveRequest(command.EmployeeId, command.ReplacementEmployeeId, command.FromDate, command.ToDate, command.Reason);
            await _leaveRequestRepository.AddLeaveRequestAsync(request);
            await _leaveRequestRepository.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<ICollection<AllLeaveRequestDTO>> GetAllLeaveRequestAsync()
    {
        var AllRequests = await _leaveRequestRepository.GetAllRequestAsync();
        var DTO = new List<AllLeaveRequestDTO>();
        foreach (var item in AllRequests)
        {
            var CountApproved = AllRequests.Count(a => a.EmployeeId == item.EmployeeId && a.Status == Status.Approved);
            var CountRejected = AllRequests.Count(a => a.EmployeeId == item.EmployeeId && a.Status == Status.Rejected);

            var Request = new AllLeaveRequestDTO()
            {
                Id = item.Id,
                Status = item.Status,
                EmployeeFullName = item.Employee.FullName,
                EmployeeId = item.EmployeeId,
                ToDate = item.ToDate,
                FromDate = item.FromDate,
                Reason = item.Reason,
                ReplacementEmployeeId = (Guid)item.ReplacementId!,
                ReplacementFullName = item.ReplaceEmployee.FullName,
                TotalApprovedHours = await _leaveRequestRepository.GetTotalApprovedHoursAsync(item.EmployeeId),
                CountOfApproved = CountApproved,
                CountOfRejected = CountRejected,
            };
            DTO.Add(Request);
        }
        return DTO;
    }

    public async Task UpdateLeaveRequestAsync(UpdateRequestCommand command)
    {
        var Request = await _leaveRequestRepository.GetLeaveRequestById(command.RequestId);
        Request.UpdateStatus(command.Status); 
        await _leaveRequestRepository.UpdateLeaveRequest(Request);
        await _leaveRequestRepository.SaveChangesAsync();
    }
}