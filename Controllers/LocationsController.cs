using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Locations>>> GetAllLocation()
        {
            return Ok(await _locationService.GetAll());
        }
        [HttpGet("{location_Id}")]
        public async Task<ActionResult<Locations>> GetLocation(int location_Id)
        {
            var location = await _locationService.GetLocation(location_Id);
            if (location == null)
            {
                return BadRequest("Location not found");
            }
            return Ok(location);
        }

        [HttpPost]
        public async Task<ActionResult<Locations>> CreateLocation(int location_ID, int RoomID, string floor, string denomination)
        {
            var location = await _locationService.CreateLocation(location_ID, RoomID,floor,denomination);
            if (location == null)
            {
                return BadRequest("Location cannot be created");
            }
            return Ok(location);
        }

        [HttpPut("{location_Id}")]
        public async Task<ActionResult<Locations>> UpdateLocation(int location_ID, int RoomId, string? floor = null, string? denomination = null)
        {
            var location = await _locationService.UpdateLocation(location_ID,RoomId,floor,denomination);
            if (location == null)
            {
                return BadRequest("The Location does not exist");
            }
            return Ok(location);
        }

        [HttpDelete("{location_Id}")]
        public async Task<ActionResult<Locations>> DeleteLocation(int location_Id)
        {
            var location = await _locationService.DeleteLocation(location_Id);
            if (location == null)
            {
                return BadRequest("The Location does not exist");
            }
            return Ok("Location Deleted");
        }
    }
}
