using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedsController : ControllerBase
    {
        private readonly IBedService _bedService;

        public BedsController(IBedService bedService)
        {
            _bedService = bedService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beds>>> GetAllBeds()
        {
            return Ok(await _bedService.GetAll());
        }
        [HttpGet("{Bed_ID}")]
        public async Task<ActionResult<Beds>> GetBeds(int Bed_ID)
        {
            var bed = await _bedService.GetBeds(Bed_ID);
            if (bed == null)
            {
                return BadRequest("Availability not found");
            }
            return Ok(bed);
        }

        [HttpPost]
        public async Task<ActionResult<Beds>> CreateBeds(int Bed_ID, int patientId, int roomId, int stock)
        {
            var bed = await _bedService.CreateBeds(Bed_ID, patientId, roomId, stock);   
            if (bed == null)
            {
                return BadRequest("Bed cannot be created");
            }
            return Ok(bed);
        }

        [HttpPut("{Bed_ID}")]
        public async Task<ActionResult<Appointment>> UpdateBeds(int bed_ID, int patientId, int roomId, int stock)
        {
            var bed = await _bedService.UpdateBeds(bed_ID, patientId, roomId, stock);
            if (bed == null)
            {
                return BadRequest("The Availability does not exist");
            }
            return Ok(bed);
        }

        [HttpDelete("{Bed_ID}")]
        public async Task<ActionResult<Beds>> DeleteBeds(int Bed_ID)
        {
            var bed = await _bedService.DeleteBeds(Bed_ID);
            if (bed == null)
            {
                return BadRequest("The Bed does not exist");
            }
            return Ok("Bed Deleted");
        }
    }
}
