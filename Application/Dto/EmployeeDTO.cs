namespace Application.Dto;

public class EmployeeDTO
{
    public Guid Id { get;  set; }
    public string FullName { get;  set; }
    public string Email { get;  set; }
    public ICollection<LeaveRequestDTO> LeaveRequestDtos { get; set; } = new List<LeaveRequestDTO>();
}