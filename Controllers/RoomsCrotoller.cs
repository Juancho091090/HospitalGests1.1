using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsService _roomsService;

        public RoomsController(IRoomsService roomsService)
        {
            _roomsService = roomsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beds>>> GetAllRooms()
        {
            return Ok(await _roomsService.GetAll());
        }

        [HttpGet("{RoomID}")]
        public async Task<ActionResult<Beds>> GetRoom(int RoomID)
        {
            var room = await _roomsService.GetRooms(RoomID);
            if (room == null)
            {
                return BadRequest("Room not found");
            }
            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<Beds>> CreateRooms(int PatientId, string statusRoom, int location_Id, int bed_Id)
        {
            var room = await _roomsService.CreateRooms(PatientId, statusRoom, location_Id, bed_Id); 
            if (room == null)
            {
                return BadRequest("Room cannot be created");
            }
            return Ok(room);
        }

        [HttpPut("{RoomID}")]
        public async Task<ActionResult<Appointment>> UpdateRooms(int roomID, int PatientId, int location_Id, int bed_Id, string? statusRoom = null)
        {
            var room = await _roomsService.UpdateRooms(roomID, PatientId, location_Id, bed_Id);
            if (room == null)
            {
                return BadRequest("The Room does not exist");
            }
            return Ok(room);
        }

        [HttpDelete("{RoomID}")]
        public async Task<ActionResult<Beds>> DeleteRooms(int roomID)
        {
            var room = await _roomsService.DeleteRooms(roomID);
            if (room == null)
            {
                return BadRequest("The Room does not exist");
            }
            return Ok("Room Deleted");
        }
    }
}
