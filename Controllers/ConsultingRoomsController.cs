using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultingRoomsController : ControllerBase
    {
        private readonly IConsultingRoomService _consultingRoomService;

        public ConsultingRoomsController(IConsultingRoomService consultingRoomService)
        {
            _consultingRoomService = consultingRoomService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultingRooms>>> GetAllConsultingRooms()
        {
            return Ok(await _consultingRoomService.GetAll());
        }
        [HttpGet("{consultingRoomId}")]
        public async Task<ActionResult<ConsultingRooms>> GetConsultingRoom(int consultingRoomId)
        {
            var consultingRoom = await _consultingRoomService.GetConsultingRoom(consultingRoomId);
            if (consultingRoom == null)
            {
                return BadRequest("ConsultingRoom not found");
            }
            return Ok(consultingRoom);
        }

        [HttpPost]
        public async Task<ActionResult<ConsultingRooms>> CreateConsultingRoom(int roomID, int location_ID, int departmentId)
        {
            var consultingRoom = await _consultingRoomService.CreateConsultingRoom(roomID, location_ID, departmentId);  
            if (consultingRoom == null)
            {
                return BadRequest("ConsultingRoom cannot be created");
            }
            return Ok(consultingRoom);
        }

        [HttpPut("{consultingRoomId}")]
        public async Task<ActionResult<ConsultingRooms>> UpdateConsultingRoom(int consultingRoomId, int roomID, int location_ID, int departmentId)
        {
            var consultingRoom = await _consultingRoomService.UpdateConsultingRoom(consultingRoomId, roomID, location_ID, departmentId);
            if (consultingRoom == null)
            {
                return BadRequest("The ConsultingRoom does not exist");
            }
            return Ok(consultingRoom);
        }

        [HttpDelete("{consultingRoomId}")]
        public async Task<ActionResult<Beds>> DeleteConsultingRoom(int consultingRoomId)
        {
            var consultingRoom = await _consultingRoomService.DeleteConsultingRoom(consultingRoomId);
            if (consultingRoom == null)
            {
                return BadRequest("The Bed does not exist");
            }
            return Ok("Bed Deleted");
        }
    }
}
