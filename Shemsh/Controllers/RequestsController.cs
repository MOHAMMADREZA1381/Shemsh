using Application.Commands;
using Application.IServices;
using Domain.IRepositories;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shemsh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly ILeaveRequestService _leaveRequest;
        public RequestsController(ILeaveRequestService leaveRequest)
        {
            _leaveRequest = leaveRequest;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRequest()
        {
            return Ok(await _leaveRequest.GetAllLeaveRequestAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddNewRequest(NewRequestCommand newRequestCommand)
        {
            if (ModelState.IsValid)
            {
                var resualt = await _leaveRequest.AddNewRequestAsync(newRequestCommand);
                if (resualt == true)
                    return Ok("Sucess");
                else
                    return Ok("Employee Is Not Free");
            }

            return NotFound("User Not Found");
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateRequestStatus([FromForm]UpdateRequestCommand command)
        {
            if (ModelState.IsValid)
            {
                await _leaveRequest.UpdateLeaveRequestAsync(command);
                return Ok();
            }
            return Ok();
        }

    }
}
