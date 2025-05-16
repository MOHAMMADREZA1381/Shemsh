using Domain.Models;

namespace Application.Commands;

public class AddEmployeeCommand
{
    public string FullName { get;  set; }
    public string Email { get;  set; }
}