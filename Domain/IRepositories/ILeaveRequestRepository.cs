using Domain.Models;

namespace Domain.IRepositories;

public interface ILeaveRequestRepository
{
    Task AddLeaveRequestAsync(LeaveRequest request);
    Task<ICollection<LeaveRequest>> GetAllRequestAsync();
    Task<bool> IsAnyActiveLeaveRequestAsync(Guid id, DateTime FromDate, DateTime ToDate);
    Task<ICollection<LeaveRequest>> GetLeaveRequestByUserIdAsync(Guid guid);
    Task<double> GetTotalApprovedHoursAsync(Guid employeeid);
    Task UpdateLeaveRequest(LeaveRequest request);
    Task<LeaveRequest> GetLeaveRequestById(Guid guid);
    Task<bool> IsAnyLeaveRequest(Guid guid);
    Task SaveChangesAsync();
}