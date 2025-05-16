using Application.Commands;
using Application.Dto;

namespace Application.IServices;

public interface ILeaveRequestService
{
    Task<bool> AddNewRequestAsync(NewRequestCommand command);
    Task<ICollection<AllLeaveRequestDTO>> GetAllLeaveRequestAsync();
    Task UpdateLeaveRequestAsync(UpdateRequestCommand command);
}