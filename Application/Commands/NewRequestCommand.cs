namespace Application.Commands;

public class NewRequestCommand
{
    public Guid EmployeeId { get;  set; }
    public Guid ReplacementEmployeeId { get; set; }
    public DateTime FromDate { get;  set; }
    public DateTime ToDate { get;  set; }
    public string Reason { get;  set; }
}
