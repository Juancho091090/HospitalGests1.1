using Azure;
using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperatingRoomsController : ControllerBase
    {
            private readonly IOperatingService _operatingService;

            public OperatingRoomsController (IOperatingService operatingService)
            {
                _operatingService = operatingService;
            }
        [HttpGet]
            public async Task<ActionResult<List<OperatingRooms>>> GetAllOperatingRooms()
            {
                return Ok(await _operatingService.GetAll());
            }
            [HttpGet("{operatingRoomId}")]
            public async Task<ActionResult<OperatingRooms>> GetOperatingRooms(int operatingRoomId)
            {
                var operating = await _operatingService.GetOperatingRoom(operatingRoomId);
                if (operating == null)
                {
                    return BadRequest("Operating Rooms not found");
                }
                return Ok(operating);
            }

            [HttpPost]
            public async Task<ActionResult<OperatingRooms>> CreateOperatingRooms(int department_Id, string operatingRoomStatus, int doctorId, int patientId)
            {
                var operating = await _operatingService.CreateOperatingRoom(department_Id, operatingRoomStatus, doctorId, patientId);
                if (operating == null)
                {
                    return BadRequest("Operating Rooms cannot be created");
                }
                return Ok(operating);
            }

            [HttpPut("{operatingRoomId}")]
            public async Task<ActionResult<OperatingRooms>> UpdateOperatingRooms(int operatingRoomId, int department_Id, string? operatingRoomStatus, int doctorId, int patientId)
            {
                var operating = await _operatingService.UpdateOperatingRoom(operatingRoomId, department_Id, operatingRoomStatus, doctorId, patientId);
                if (operating == null)
                {
                    return BadRequest("The Operating Rooms does not exist");
                }
                return Ok(operating);
            }

            [HttpDelete("{operatingRoomId}")]
            public async Task<ActionResult<OperatingRooms>> DeleteOperatingRooms(int operatingRoomId)
            {
                var operating = await _operatingService.DeleteOperatingRoom(operatingRoomId);
                if (operating == null)
                {
                    return BadRequest("The Operating Rooms does not exist");
                }
                return Ok("Operating Rooms Deleted");
            }
        }
}
