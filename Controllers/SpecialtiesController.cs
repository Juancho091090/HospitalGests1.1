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
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialitiesService _specialtiesService;

        public SpecialtiesController(ISpecialitiesService specialtiesService)
        {
            _specialtiesService = specialtiesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Beds>>> GetAllSpecialties()
        {
            return Ok(await _specialtiesService.GetAll());
        }

        [HttpGet("{SpecialitieId}")]
        public async Task<ActionResult<Beds>> GetSpecialty(int SpecialitieId)
        {
            var specialty = await _specialtiesService.GetSpecialties(SpecialitieId);
            if (specialty == null)
            {
                return BadRequest("Specialty not found");
            }
            return Ok(specialty);
        }

        [HttpPost]
        public async Task<ActionResult<Beds>> CreateSpecialties(string specialitieName)
        {
            var specialty = await _specialtiesService.CreateSpecialties(specialitieName);
            if (specialty == null)
            {
                return BadRequest("Specialty cannot be created");
            }
            return Ok(specialty);
        }

        [HttpPut("{SpecialitieId}")]
        public async Task<ActionResult<Appointment>> UpdateSpecialties(int specialitieId, string? specialitieName = null)
        {
            var specialty = await _specialtiesService.UpdateSpecialties(specialitieId, specialitieName);
            if (specialty == null)
            {
                return BadRequest("The Specialty does not exist");
            }
            return Ok(specialty);
        }

        [HttpDelete("{SpecialitieId}")]
        public async Task<ActionResult<Beds>> DeleteSpecialties(int specialitieId)
        {
            var specialty = await _specialtiesService.DeleteSpecialties(specialitieId);
            if (specialty == null)
            {
                return BadRequest("The Specialty does not exist");
            }
            return Ok("Specialty Deleted");
        }
    }
}
