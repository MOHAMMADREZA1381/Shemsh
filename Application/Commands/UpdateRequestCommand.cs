using Domain.Models;

namespace Application.Commands;

public class UpdateRequestCommand
{
    public Guid RequestId{ get; set; }
    public Status Status{ get; set; }
}