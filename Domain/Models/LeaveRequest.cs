using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public class LeaveRequest
{
    public LeaveRequest(Guid employeeId, Guid replacementEmployeeId, DateTime fromDate, DateTime toDate, string reasone)
    {
        Id = Guid.NewGuid();
        EmployeeId = employeeId;
        ReplacementId = replacementEmployeeId;
        FromDate = fromDate;
        ToDate = toDate;
        Reason = reasone;
        Status = Status.Pending;
    }


    [Key]
    public Guid Id { get;private set; }
    public Guid EmployeeId { get;private set; }
    public Guid? ReplacementId { get;private set; }
    public DateTime FromDate { get;private set; }
    public DateTime ToDate { get;private set; }
    public string Reason { get;private set; }
    public Status Status{ get;private set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee{ get; set; }

    [ForeignKey("ReplacementId")]
    public Employee ReplaceEmployee { get; set; }

    public void UpdateStatus(Status status)
    {
        Status = status;
    }



    private LeaveRequest()
    {
        
    }
}


public enum Status
{
    Pending, Approved, Rejected
}