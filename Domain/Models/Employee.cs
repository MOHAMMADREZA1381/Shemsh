using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Employee
{

    public Employee( string fullName, string email)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
        Email = email;
    }

    [Key]
    public Guid Id{ get;private set; }
    public string FullName{ get;private set; }
    public string Email{ get;private set; }

    private Employee()
    {

    }
}