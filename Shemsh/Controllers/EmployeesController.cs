using Application.Commands;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shemsh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ILeaveRequestService _requestService;
        private readonly IEmployeeService _employeeService;

        public EmployeesController(ILeaveRequestService requestService, IEmployeeService employeeService)
        {
            _requestService = requestService;
            _employeeService = employeeService;
        }


        [HttpPost("employee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeCommand command)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployee(command);
                return Ok();
            }
            return Ok();
        }

        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetEmployee(Guid UserId)
        {
            if (ModelState.IsValid)
            {
                var IsAny = await _employeeService.IsAnnyEmployeeAsync(UserId);
                if (IsAny==true)
                {
                    return Ok(await _employeeService.GetEmployeeAsync(UserId));
                }

                return NotFound("User Not Found");
            }

            return BadRequest();
        }




    }
}
