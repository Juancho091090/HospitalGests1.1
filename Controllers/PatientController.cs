using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
            private readonly IPatientService _patientService;

            public PatientController(IPatientService patientService)
            {
            _patientService = patientService;
            }
            [HttpGet]
            public async Task<ActionResult<List<Patients>>> GetAllPatients()
            {
                return Ok(await _patientService.GetAll());
            }
            [HttpGet("{ patientId}")]
            public async Task<ActionResult<Patients>> GetPatients(int patientId)
            {
                var patients = await _patientService.GetPatients(patientId);
                if (patients == null)
                {
                    return BadRequest("Patients not found");
                }
                return Ok(patients);
            }

            [HttpPost]
            public async Task<ActionResult<Patients>> CreatePatients(int patientId)
            {
                var patients = await _patientService.CreatePatients(patientId);
                if (patients == null)
                {
                    return BadRequest("Patients cannot be created");
                }
                return Ok(patients);
            }

            [HttpPut("{ patientId}")]
            public async Task<ActionResult<Patients>> UpdatePharmacy(int patientId, int IdPerson)
            {
                var patients = await _patientService.UpdatePatients( patientId, IdPerson);
                if (patients == null)
                {
                    return BadRequest("The Patients does not exist");
                }
                return Ok(patients);
            }

            [HttpDelete("{patientId}")]
            public async Task<ActionResult<Patients>> DeletePatients(int patientId)
            {
                var patients = await _patientService.DeletePatients(patientId);
                if (patients == null)
                {
                    return BadRequest("The Patients does not exist");
                }
                return Ok("Patients Deleted");
            }
        }
}
