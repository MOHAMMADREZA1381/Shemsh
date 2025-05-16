using Domain.Models;

namespace Application.Dto;

public class AllLeaveRequestDTO
{
    public Guid Id { get;  set; }
    public Guid EmployeeId { get;  set; }
    public string EmployeeFullName{ get; set; }
    public Guid ReplacementEmployeeId { get; set; }
    public string ReplacementFullName{ get; set; }
    public DateTime FromDate { get;  set; }
    public DateTime ToDate { get;  set; }
    public string Reason { get;  set; }
    public Status Status { get;  set; }
    public int CountOfApproved{ get; set; }
    public int CountOfRejected { get; set; }
    public double TotalApprovedHours { get; set; }

}