using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Occupation>>> GetOccupation()
        {
            return Ok(await _occupationService.GetAll());
        }

        [HttpGet("{occupation_Id}")]
        public async Task<ActionResult<Occupation>> GetOccupation(int occupation_Id)
        {
            var occupation = await _occupationService.GetOccupation(occupation_Id);
            if (occupation == null)
            {
                return BadRequest("Occupation not found");
            }
            return Ok(occupation);
        }

        [HttpPost]
        public async Task<ActionResult<Occupation>> CreateOccupation(int roomID, int patientId, int doctorId, int locationId, string type, DateTime startDateTime, DateTime endDateTime)
        {
            var occupation = await _occupationService.CreateOccupation(roomID, patientId, doctorId, locationId, type, startDateTime, endDateTime);
            if (occupation == null)                
            {
                return BadRequest("Occupation cannot be created");
            }
            return Ok(occupation);
        }

        [HttpPut("{occupation_Id}")]
        public async Task<ActionResult<Occupation>> UpdateOccupation(int occupationId, int roomID, int patientId, int doctorId, int locationId, string? type = null, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            var occupation = await _occupationService.UpdateOccupation(occupationId, roomID, patientId, doctorId, locationId, type, startDateTime, endDateTime);
            if (occupation == null)
            {
                return BadRequest("The Occupation does not exist");
            }
            return Ok(occupation);

        }
        [HttpDelete("{occupation_Id}")]
        public async Task<ActionResult<Occupation>> DeleteOccupation(int occupation_Id)
        {
            var occupation = await _occupationService.GetOccupation(occupation_Id);
            if (occupation == null)
            {
                return BadRequest("The Occupation does not exist");
            }
            return Ok("Medicationdelivery Deleted");
        }

    }
}