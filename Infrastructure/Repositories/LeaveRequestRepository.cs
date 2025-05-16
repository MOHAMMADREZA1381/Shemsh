using Azure.Core;
using Domain.IRepositories;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LeaveRequestRepository:ILeaveRequestRepository
{
    private readonly MyContext _context;

    public LeaveRequestRepository(MyContext context)
    {
        _context = context;
    }


    public async Task AddLeaveRequestAsync(LeaveRequest request)
    {
        await _context.AddAsync(request);
    }

    public async Task<ICollection<LeaveRequest>> GetAllRequestAsync()
    {
        return await _context.LeaveRequests.Include(a=>a.Employee).Include(a=>a.ReplaceEmployee).ToListAsync();
    }

    public async Task<bool> IsAnyLeaveRequestAsync(Guid id, DateTime fromDate, DateTime toDate)
    {
        return await _context.LeaveRequests.AnyAsync(a =>
            a.EmployeeId == id || a.ReplacementId == id &&
            a.Status == Status.Approved &&
            a.FromDate <= toDate &&
            a.ToDate >= fromDate);
    }

    public async Task<ICollection<LeaveRequest>> GetLeaveRequestByUserIdAsync(Guid guid)
    {
        return await _context.LeaveRequests.Where(a => a.EmployeeId == guid).ToListAsync();
    }

    public async Task<double> GetTotalApprovedHoursAsync(Guid employeeid)
    {
        var totalHours = (await _context.LeaveRequests.Where(a => a.EmployeeId == employeeid && a.Status==Status.Approved && a.FromDate>=DateTime.Now.AddDays(-30)).ToListAsync()).Sum(a => (a.ToDate - a.FromDate).TotalHours);
        return totalHours;
    }

    public async Task UpdateLeaveRequest(LeaveRequest request)
    {
         _context.Update(request);
    }

    public async Task<LeaveRequest> GetLeaveRequestById(Guid guid)
    {
        return await _context.LeaveRequests.FirstOrDefaultAsync(a => a.Id == guid);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}