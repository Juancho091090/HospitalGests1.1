using HospitalGests.Model;
using HospitalGests.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalGests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _PrescriptionService;

        public PrescriptionController(IPrescriptionService PrescriptionService)
        {
            _PrescriptionService = PrescriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Prescriptions>>> GetAllPrescriptions()
        {
            return Ok(await _PrescriptionService.GetAll());
        }
        [HttpGet("{IdPrescription}")]
        public async Task<ActionResult<Prescriptions>> GetPrescriptions(int idPrescription)
        {
            var prescriptions = await _PrescriptionService.GetPrescriptions(idPrescription);
            if (prescriptions== null)
            {
                return BadRequest("Availability not found");
            }
            return Ok(prescriptions);
        }

        [HttpPost]
        public async Task<ActionResult<Prescriptions>> CreatePrescriptions(int medicalRecordId, int medicineId, string dose, string duration, DateOnly dateissue, string state)
        {
            var prescriptions = await _PrescriptionService.CreatePrescriptions(medicalRecordId, medicineId, dose, duration, dateissue, state);
            if (prescriptions == null)
            {
                return BadRequest("Prescriptions cannot be created");
            }
            return Ok(prescriptions);
        }

        [HttpPut("{IdPrescription}")]
        public async Task<ActionResult<Appointment>> UpdatePrescriptions(int idPrescription, int medicalRecordId, int? medicineId = null, string? dose = null, string? duration = null, DateOnly? dateissue = null, string? state = null)
        {
            var prescriptions = await _PrescriptionService.UpdatePrescriptions(idPrescription, medicalRecordId, medicineId, dose, duration, dateissue, state);
            if (prescriptions == null)
            {
                return BadRequest("The Availability does not exist");
            }
            return Ok(prescriptions);
        }

        [HttpDelete("{IdPrescription}")]
        public async Task<ActionResult<Prescriptions>> DeletePrescriptions(int IdPrescription)
        {
            var prescriptions = await _PrescriptionService.DeletePrescriptions(IdPrescription);
            if (prescriptions == null)
            {
                return BadRequest("The Prescriptions does not exist");
            }
            return Ok("Prescription Deleted");
        }
    }
}
