using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctors()
        {
            return Ok(await _doctorService.GetAll());
        }
        [HttpGet("{doctorId}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int doctorId)
        {
            var doctor = await _doctorService.GetDoctor(doctorId);
            if (doctor == null)
            {
                return BadRequest("Doctor not found");
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> CreateDoctor(int idPerson, int specialitieId, string observations)
        {
            var doctor = await _doctorService.CreateDoctor(idPerson, specialitieId, observations);
            if (doctor == null)
            {
                return BadRequest("Doctor cannot be created");
            }
            return Ok(doctor);
        }

        [HttpPut("{doctorId}")]
        public async Task<ActionResult<Doctor>> UpdateDoctor(int doctor_Id, int idPerson, int? specialitieId = null, string? observations = null)
        {
            var doctor = await _doctorService.UpdateDoctor(doctor_Id,idPerson, specialitieId, observations);
            if (doctor == null)
            {
                return BadRequest("The Doctor does not exist");
            }
            return Ok(doctor);
        }

        [HttpDelete("{doctorId}")]
        public async Task<ActionResult<Doctor>> DeleteDoctor(int doctorId)
        {
            var doctor = await _doctorService.GetDoctor(doctorId);
            if (doctor == null)
            {
                return BadRequest("The Doctor does not exist");
            }
            return Ok("Doctor Deleted");
        }
    }
}



