using Domain.Models;

namespace Application.Dto;

public class LeaveRequestDTO
{
    public Guid Id { get;  set; }
    public Guid ReplacementEmployeeId { get; set; }
    public DateTime FromDate { get;  set; }
    public DateTime ToDate { get;  set; }
    public string Reason { get;  set; }
    public Status Status { get;  set; }
}