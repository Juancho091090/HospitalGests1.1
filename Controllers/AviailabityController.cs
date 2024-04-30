using HospitalGests.Model;
using HospitalGests.Repositories;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AviailabityController : ControllerBase
    {
        private readonly IAvailabityServices _availabityServices;

        public AviailabityController(IAvailabityServices availabityServices)
        {
            _availabityServices = availabityServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<Availability>>> GetAllAvailability()
        {
            return Ok(await _availabityServices.GetAll());
        }
        [HttpGet("{AvailabilityId}")]
        public async Task<ActionResult<Availability>> GetAvailability(int AvailabilityId)
        {
            var availability = await _availabityServices.GetAvailability(AvailabilityId);
            if (availability == null)
            {
                return BadRequest("Availability not found");
            }
            return Ok(availability);
        }

        [HttpPost]
        public async Task<ActionResult<Availability>> CreateAvailability(int doctorId, DateTime? startDateTime, DateTime? endDateTime)
        {
            var availability = await _availabityServices.CreatAvailability( doctorId, startDateTime, endDateTime); 
            if (availability == null)
            {
                return BadRequest("Availability cannot be created");
            }
            return Ok(availability);
        }

        [HttpPut("{AvailabilityId}")]
        public async Task<ActionResult<Appointment>> UpdateAvialability(int availabilityId, int doctorId, DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            var availability = await _availabityServices.UpdateAvialability(availabilityId, doctorId, startDateTime, endDateTime);
            if (availability == null)
            {
                return BadRequest("The Availability does not exist");
            }
            return Ok(availability);
        }

        [HttpDelete("{AvailabilityId}")]
        public async Task<ActionResult<Appointment>> DeleteAvailability(int AvailabilityId)
        {
            var availability = await _availabityServices.DeleteAvailability(AvailabilityId);
            if (availability == null)
            {
                return BadRequest("The Availability does not exist");
            }
            return Ok("Availability Deleted");
        }
    }
}
